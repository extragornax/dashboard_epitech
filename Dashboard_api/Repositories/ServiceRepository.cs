/*
** EPITECH PROJECT, 2018
** Dashboard_api
** File description:
** ServiceRepository
*/

using System.Collections.Generic;

using MongoDB.Bson;
using MongoDB.Driver;

namespace Dashboard.Models
{
    public class ServiceRepository
    {
        private MongoClient _dbClient;
        private IMongoDatabase _database;
        private IMongoCollection<Service> _collection;

        public ServiceRepository(string connection)
        {
            if (string.IsNullOrWhiteSpace(connection))
                connection = "mongodb://root:example@localhost:27017";
            _dbClient = new MongoDB.Driver.MongoClient(connection);
            _database = _dbClient.GetDatabase("dashboard");
            _collection = _database.GetCollection<Service>("Service");

            System.Console.WriteLine("patate");
            var count = _collection.CountDocuments(new BsonDocument());
            if (count != 1)
            {
                _collection.DeleteMany(new BsonDocument());
                var service = new Service();
                service.Name = "weather";
                service.Widgets.Add(new Widgets.WeatherConditions());
                service.Widgets.Add(new Widgets.WeatherConditions());
                _collection.InsertOne(service);
            }
        }

        public IEnumerable<Service> GetAll()
        {
            return _collection.Find(new BsonDocument()).ToList();
        }

        public long CountAll()
        {
            var count = _collection.CountDocuments(new BsonDocument());
            return count;
        }

        public Service Get(string id)
        {
            var filter = Builders<Service>.Filter.Eq("_id", ObjectId.Parse(id));
            return _collection.Find(filter).FirstOrDefault();
        }

        public Service GetByName(string name)
        {
            var filter = Builders<Service>.Filter.Eq("Name", name);
            return _collection.Find(filter).FirstOrDefault();
        }

        public Service Add(Service item)
        {
            _collection.InsertOne(item);
            return item;
        }

        public bool Remove(string id)
        {
            var filter = Builders<Service>.Filter.Eq("_id", id);
            var result = _collection.DeleteOne(filter);
            return result.DeletedCount == 1;
        }

        public Service Update(string id, Service item)
        {
            var filter = Builders<Service>.Filter.Eq("_id", id);
            var result = _collection.FindOneAndReplace(filter, item);
            return result;
        }
    }
}
