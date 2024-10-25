using MongoDB.Bson;
using MongoDB.Driver;
using SpyCheif.Application.BaseNosql;
using SpyCheif.Application.Exception;
using SpyCheif.Domain.Entity;
using System.Text.Json;

namespace SpyCheif.Persistance.MongoDb.Base
{
    public class MongoBaseWriteRepository<T> : IBaseNoSqlWriteRepository<T> where T : BaseEntity, new()
    {
        public MongoClient _client { get; set; }
        public IMongoDatabase _database { get; set; }
        public IMongoCollection<BsonDocument> _collection { get; set; }

        public MongoBaseWriteRepository(MongoClient client)
        {
            _client = client;
        }

        public void SetDatabase(string databaseName)
        {
            _database = _client.GetDatabase(databaseName);
        }

        public void SetCollection(string collectionName)
        {
            if (_database != null)
                _collection = _database.GetCollection<BsonDocument>(collectionName);
            else
                throw new NullReferenceException(ExceptionMessage.NullReferenceException);
        }

        public T Add(T entity)
        {
            string entityJson = JsonSerializer.Serialize(entity);
            BsonDocument entityDoc = BsonDocument.Parse(entityJson);
            _collection.InsertOne(entityDoc);
            return entity;
        }

        public async Task<T> AddAsync(T entity)
        {
            BsonDocument entityDoc = BsonDocument.Create(entity);
            await _collection.InsertOneAsync(entityDoc);
            return entity;
        }

        public void AddList(List<T> entities)
        {
            List<BsonDocument> entitiesDoc = new List<BsonDocument>();
            foreach (var entity in entities)
            {
                entitiesDoc.Add(BsonDocument.Create(entity));
            }
            _collection.InsertMany(entitiesDoc);
        }

        public async Task AddListAsync(List<T> entities)
        {
            List<BsonDocument> entitiesDoc = new List<BsonDocument>();
            foreach (var entity in entities)
            {
                entitiesDoc.Add(BsonDocument.Create(entity));
            }
            await _collection.InsertManyAsync(entitiesDoc);
        }

        public bool Delete(Guid id)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("_id", id);
            DeleteResult result = _collection.DeleteOne(filter);
            if (result.DeletedCount > 0)
                return true;
            return false;
        }

        public bool DeleteRange(List<Guid> guids)
        {
            var filter = Builders<BsonDocument>.Filter.In("_id", guids);
            DeleteResult result = _collection.DeleteOne(filter);
            if (result.DeletedCount > 0)
                return true;
            return false;
        }

        public T Update(T entity)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("_id", entity.Id);
            var entityDoc = BsonDocument.Create(entity);
            _collection.UpdateOne(filter, entityDoc);
            return entity;
        }

        public void UpdateList(List<T> entities)
        {
            foreach (var entity in entities)
            {
                var filter = Builders<BsonDocument>.Filter.Eq("_id", entity.Id);
                var entityDoc = BsonDocument.Create(entity);
                _collection.UpdateOne(filter, entityDoc);
            }
        }
    }
}
