using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace BookWebService.Models
{
    public class DemandModel
    {
        [BsonElement("_id")]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId ID { get; set; }
        [BsonElement("Username")]
        [BsonRepresentation(BsonType.String)]
        public string Username { get; set; }
        [BsonElement("BookID")]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId BookID { get; set; }
        [BsonElement("Date")]
        [BsonRepresentation(BsonType.DateTime)]
        public DateTime Date { get; set; } 
    }
}