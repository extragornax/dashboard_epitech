/*
** EPITECH PROJECT, 2018
** dashboard
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

            Widgets.IWidget Weather = new Widgets.WeatherConditions();
            Weather.Intake("Paris,fr");
            Weather.Invoke(new User());
        }

        public IEnumerable<User> GetAll() { return _collection.Find(new BsonDocument()).ToList(); }

        public long CountAll()
        {
            long count = _collection.CountDocuments(new BsonDocument());
            return count;
        }

        public User Get(string id)
        {
            MongoDB.Driver.FilterDefinition<Dashboard.Models.User> filter = Builders<User>.Filter.Eq("_id", ObjectId.Parse(id));
            return _collection.Find(filter).FirstOrDefault();
        }

        public User GetByName(string name)
        {
            MongoDB.Driver.FilterDefinition<Dashboard.Models.User> filter = Builders<User>.Filter.Eq("Name", name);
            return _collection.Find(filter).FirstOrDefault();
        }

        public User Add(User item)
        {
            _collection.InsertOne(item);
            return item;
        }

        public bool Remove(string id)
        {
            MongoDB.Driver.FilterDefinition<Dashboard.Models.User> filter = Builders<User>.Filter.Eq("_id", id);
            MongoDB.Driver.DeleteResult result = _collection.DeleteOne(filter);
            return result.DeletedCount == 1;
        }

        public User Update(string id, User item)
        {
            MongoDB.Driver.FilterDefinition<Dashboard.Models.User> filter = Builders<User>.Filter.Eq("_id", id);
            Dashboard.Models.User result = _collection.FindOneAndReplace(filter, item);
            return result;
        }
    }
}
