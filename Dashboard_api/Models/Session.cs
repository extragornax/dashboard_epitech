using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace dashboard_api.Models {
    public class Session {
        [BsonId]
        public ObjectId Id { get; set; }
        public ObjectId UserId { get; set; }
    }
}
