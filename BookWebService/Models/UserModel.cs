using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BookWebService.Models
{
    public class UserModel
    {
        [BsonElement("_id")]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId ID { get; set; }
        [BsonElement("Username")]
        [BsonRepresentation(BsonType.String)]
        public string Username { get; set; }
        [BsonElement("Password")]
        [BsonRepresentation(BsonType.String)]
        public string Password { get; set; }
        [BsonElement("Library")]
        [BsonRepresentation(BsonType.String)]
        public string Library { get; set; }

    }
}