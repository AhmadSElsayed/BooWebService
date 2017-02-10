using BookWebService.Models;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BookWebService.Controllers.Database
{
    /// <summary>
    /// Manipulates Demands in the database
    /// </summary>
    public class DemandDatabaseController
    {
        /// <summary>
        /// Creates a Demand and registers in the database
        /// </summary>
        /// <param name="BookID">Book ID demanded</param>
        /// <param name="Username">Username that demanded the Book</param>
        /// <returns>true if successful, false otherwise</returns>
        public static bool CreateDemand(ObjectId BookID, string Username)
        {
            if (!(UserDatabaseController.UserExists(Username) && BookDatabaseController.BookExists(BookID)))
                return false;
            var temp = new DemandModel()
            {
                Username = Username,
                BookID = BookID,
                Date = DateTime.Now
            };
            var Collection = MongoDBController.GetCollection<BsonDocument>("Crossover", "Demand");           
            Collection.InsertOne(temp.ToBsonDocument(typeof(DemandModel)));
            return true;
        }

        /// <summary>
        /// View User demands
        /// </summary>
        /// <param name="Username">Username string</param>
        /// <returns>List of DemandModel Objects</returns>
        public static List<DemandModel> ViewDemands(string Username)
        {
            var Collection = MongoDBController.GetCollection<BsonDocument>("Crossover", "Demand");
            var Filter = Builders<BsonDocument>.Filter.Eq("Username", Username);

            List<DemandModel> temp = new List<DemandModel>();
            foreach (var item in Collection.Find(Filter).ToList())
            {
                temp.Add(BsonSerializer.Deserialize<DemandModel>(item));
            }

            return temp;
        }
    }
}