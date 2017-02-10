using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BookWebService.Models
{
    /// <summary>
    /// The assumed book model form that the "publishers" have implemented in the database
    /// </summary>
    public class BookModel
    {        
        [BsonElement("_id")]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public ObjectId ID { get; set; }
        [BsonElement("Title")]
        [BsonRepresentation(BsonType.String)]
        public string Title { get; set; }
        [BsonElement("Publisher")]
        [BsonRepresentation(BsonType.String)]
        public string Publisher { get; set; }
        [BsonElement("Description")]
        [BsonRepresentation(BsonType.String)]
        public string Description { get; set; }
        [BsonElement("Authors")]
        [BsonRepresentation(BsonType.String)]
        public string[] Authors { get; set; }

    }
}