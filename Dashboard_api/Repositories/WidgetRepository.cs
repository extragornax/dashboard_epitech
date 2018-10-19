using System.Collections.Generic;

using MongoDB.Bson;
using MongoDB.Driver;

namespace dashboard_api.Models {
    public class WidgetRepository {
        private MongoClient _dbClient;
        private IMongoDatabase _database;
        private IMongoCollection<Widgets.IWidget> _collection;

        public WidgetRepository(string connection) {
            if (string.IsNullOrWhiteSpace(connection))
                connection = "mongodb://root:example@localhost:27017";
            _dbClient = new MongoDB.Driver.MongoClient(connection);
            _database = _dbClient.GetDatabase("dashboard");
            _collection = _database.GetCollection<Widgets.IWidget>("Widget");
        }

        public IEnumerable<Widgets.IWidget> GetAll() {
            return _collection.Find(new BsonDocument()).ToList();
        }

        public long CountAll() {
            var count = _collection.CountDocuments(new BsonDocument());
            return count;
        }

        public Widgets.IWidget Get(string id) {
            var filter = Builders<Widgets.IWidget>.Filter.Eq("_id", ObjectId.Parse(id));
            return _collection.Find(filter).FirstOrDefault();
        }

        public Widgets.IWidget GetByName(string name) {
            var filter = Builders<Widgets.IWidget>.Filter.Eq("Name", name);
            return _collection.Find(filter).FirstOrDefault();
        }

        public Widgets.IWidget Add(Widgets.IWidget item) {
            _collection.InsertOne(item);
            return item;
        }

        public bool Remove(string id) {
            var filter = Builders<Widgets.IWidget>.Filter.Eq("_id", id);
            var result = _collection.DeleteOne(filter);
            return result.DeletedCount == 1;
        }

        public Widgets.IWidget Update(string id, Widgets.IWidget item) {
            var filter = Builders<Widgets.IWidget>.Filter.Eq("_id", id);
            var result = _collection.FindOneAndReplace(filter, item);
            return result;
        }

        public void Drop() {
            _collection.DeleteMany(new BsonDocument());
        }
    }
}
