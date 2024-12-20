﻿using MongoDB.Bson;
using MongoDB.Driver;
using System.Linq.Expressions;

namespace SpyCheif.Application.BaseNosql
{
    public interface IBaseNoSqlReadRepository
    {
        public MongoClient _client { get; set; }
        public IMongoDatabase _database { get; set; }
        public IMongoCollection<BsonDocument> _collection { get; set; }

        public void SetDatabase(string databaseName);
        public void SetCollection(string collectionName);

        public List<BsonDocument> GetAll();
        public BsonDocument? Get(Expression<Func<BsonDocument, bool>> filter);
        public BsonDocument? Get(string id);

    }
}
