using MongoDB.Bson;
using MongoDB.Driver;
using SpyCheif.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SpyCheif.Application.BaseNosql
{
    public interface IBaseNoSqlWriteRepository<T> where T : BaseEntity,new()
    {
        public MongoClient _client { get; set; }
        public IMongoDatabase _database { get; set; }
        public IMongoCollection<BsonDocument> _collection { get; set; }

        public void SetDatabase(string databaseName);
        public void SetCollection(string collectionName);

        public T Add(T entity);
        public void AddList(List<T> entities);
        public Task<T> AddAsync(T entity);
        public Task AddListAsync(List<T> entities);

        public T Update(T entity);
        public void UpdateList(List<T> entities);

        public bool Delete(Guid id);
        public bool DeleteRange(List<Guid> guids);

    }
}
