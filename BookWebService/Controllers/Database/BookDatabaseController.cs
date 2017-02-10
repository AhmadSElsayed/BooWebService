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
    /// Book Search Criteria Enum
    /// </summary>
    public enum BookSearch
    {
        Publisher, Title, ID
    }

    /// <summary>
    /// Book manipulation in Database
    /// </summary>
    public class BookDatabaseController
    {
        /// <summary>
        /// Gets Book list based on certain search crieteria
        /// </summary>
        /// <param name="Field">0 if Publishern Search, 1 Title, 2 ID</param>
        /// <param name="Search">Search String</param>
        /// <returns>List of BookModel Objects that meet these criteria</returns>
        public static List<BookModel> GetBook(BookSearch Field, object Search)
        {
            var Collection = MongoDBController.GetCollection<BsonDocument>("Crossover", "Book");
            string s;
            switch (Field)
            {
                case BookSearch.Publisher:
                    s = "Publisher";
                    break;
                case BookSearch.Title:
                    s = "Title";
                    break;
                case BookSearch.ID:
                    {
                        s = "_id";
                        Search = ObjectId.Parse(Search.ToString());
                    }
                    break;
                default:
                    throw new Exception("Type Error");
            }

            var Filter = Builders<BsonDocument>.Filter.Eq(s, Search);

            List<BookModel> temp= new List<BookModel>();
            foreach (var item in Collection.Find(Filter).ToList())
            {
                temp.Add(BsonSerializer.Deserialize<BookModel>(item));
            }

            return temp;          
        }

        /// <summary>
        /// Gets All books
        /// </summary>
        /// <returns>A List of BookModel Objects</returns>
        public static List<BookModel> GetAll()
        {
            var Collection = MongoDBController.GetCollection<BsonDocument>("Crossover", "Book");

            List<BookModel> temp = new List<BookModel>();
            foreach (var item in Collection.Find(new BsonDocument()).ToList())
            {
                temp.Add(BsonSerializer.Deserialize<BookModel>(item));
            }

            return temp;
        }

        /// <summary>
        /// Checks if a book exists based on ID
        /// </summary>
        /// <param name="BookID">Book ID to search by</param>
        /// <returns>boolean</returns>
        public static bool BookExists(ObjectId BookID)
        {
            var Collection = MongoDBController.GetCollection<BsonDocument>("Crossover", "Book");
            var Filter = Builders<BsonDocument>.Filter.Eq("_id", BookID);
            if (Collection.Find(Filter).Count() > 0)
                return true;
            return false;
        }
    }
}