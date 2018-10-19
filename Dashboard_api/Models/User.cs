using Microsoft.EntityFrameworkCore;

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace dashboard_api.Models {

    public class User {
        [BsonId]
        public ObjectId Id { get; set; }
        public ObjectId SessionId { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
    }
}
