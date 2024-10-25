using MongoDB.Bson;
using MongoDB.Driver;
using SpyCheif.Application.BaseNosql;
using System.Linq.Expressions;

namespace SpyCheif.Persistance.MongoDb.Base
{
    public class MongoBaseReadRepository : IBaseNoSqlReadRepository
    {
        public MongoClient _client { get; set; }
        public IMongoDatabase _database { get; set; }
        public IMongoCollection<BsonDocument> _collection { get; set; }

        public MongoBaseReadRepository(MongoClient client)
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
        }

        public List<BsonDocument> GetAll()
        {
            var results = _collection.Find(new BsonDocument()).ToList();
            return results;
        }

        public BsonDocument? Get(Expression<Func<BsonDocument, bool>> filter)
        {
            var result = _collection.Find(filter).FirstOrDefault();
            return result;
        }

        public BsonDocument? Get(string id)
        {
            ObjectId objectId = ObjectId.Parse(id);
            var filter = Builders<BsonDocument>.Filter.Eq("_id", objectId);
            var result = _collection.Find(filter).FirstOrDefault();
            return result;
        }

    }
}
