/*
** EPITECH PROJECT, 2018
** dashboard
** File description:
** SessionRepository
*/

using System.Collections.Generic;

using MongoDB.Bson;
using MongoDB.Driver;

namespace Dashboard.Models
{
    public class SessionRepository : ISessionRepository
    {
        private MongoClient _dbClient;
        private IMongoDatabase _database;
        private IMongoCollection<Session> _collection;

        public SessionRepository(string connection)
        {
            if (string.IsNullOrWhiteSpace(connection))
                connection = "mongodb://root:example@localhost:27017";
            _dbClient = new MongoDB.Driver.MongoClient(connection);
            _database = _dbClient.GetDatabase("dashboard");
            _collection = _database.GetCollection<Session>("Session");
        }

        public IEnumerable<Session> GetAll()
        {
            return _collection.Find(new BsonDocument()).ToList();
        }

        public long CountAll()
        {
            long count = _collection.CountDocuments(new BsonDocument());
            return count;
        }

        public Session Get(string id)
        {
            MongoDB.Driver.FilterDefinition<Dashboard.Models.Session> filter = Builders<Session>.Filter.Eq("_id", ObjectId.Parse(id));
            return _collection.Find(filter).FirstOrDefault();
        }

        public Session GetByUserId(string userId)
        {
            MongoDB.Driver.FilterDefinition<Dashboard.Models.Session> filter = Builders<Session>.Filter.Eq("UserId", ObjectId.Parse(userId));
            return _collection.Find(filter).FirstOrDefault();
        }

        public Session Add(Session item)
        {
            _collection.InsertOne(item);
            return item;
        }

        public bool Remove(string id)
        {
            MongoDB.Driver.FilterDefinition<Dashboard.Models.Session> filter = Builders<Session>.Filter.Eq("_id", id);
            MongoDB.Driver.DeleteResult result = _collection.DeleteOne(filter);
            return result.DeletedCount == 1;
        }

        public Session Update(string id, Session item)
        {
            MongoDB.Driver.FilterDefinition<Dashboard.Models.Session> filter = Builders<Session>.Filter.Eq("_id", id);
            Dashboard.Models.Session result = _collection.FindOneAndReplace(filter, item);
            return result;
        }
    }
}
