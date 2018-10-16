/*
** EPITECH PROJECT, 2018
** Dashboard_api
** File description:
** UserRepository
*/

using System.Collections.Generic;

using MongoDB.Bson;
using MongoDB.Driver;

namespace Dashboard.Models
{
    public class UserRepository : IUserRepository
    {
        private MongoClient _dbClient;
        private IMongoDatabase _database;
        private IMongoCollection<User> _collection;

        public UserRepository(string connection)
        {
            if (string.IsNullOrWhiteSpace(connection))
                connection = "mongodb://root:example@localhost:27017";
            _dbClient = new MongoDB.Driver.MongoClient(connection);
            _database = _dbClient.GetDatabase("dashboard");
            _collection = _database.GetCollection<User>("User");
        }

        public IEnumerable<User> GetAll()
        {
            return _collection.Find(new BsonDocument()).ToList();
        }

        public long CountAll()
        {
            var count = _collection.CountDocuments(new BsonDocument());
            return count;
        }

        public User Get(string id)
        {
            var filter = Builders<User>.Filter.Eq("_id", ObjectId.Parse(id));
            return _collection.Find(filter).FirstOrDefault();
        }

        public User GetByName(string name)
        {
            var filter = Builders<User>.Filter.Eq("Name", name);
            return _collection.Find(filter).FirstOrDefault();
        }

        public User Add(User item)
        {
            _collection.InsertOne(item);
            return item;
        }

        public bool Remove(string id)
        {
            var filter = Builders<User>.Filter.Eq("_id", id);
            var result = _collection.DeleteOne(filter);
            return result.DeletedCount == 1;
        }

        public User Update(string id, User item)
        {
            var filter = Builders<User>.Filter.Eq("_id", id);
            var result = _collection.FindOneAndReplace(filter, item);
            return result;
        }
    }
}
