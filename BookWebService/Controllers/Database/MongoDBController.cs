using MongoDB.Driver;
using System.Configuration;

namespace BookWebService.Controllers.Database
{
    /// <summary>
    /// MongoDB Controller Utility Class
    /// </summary>
    public class MongoDBController
    {
        /// <summary>
        /// Connects to the Database whose connection string is in the Web.Config
        /// </summary>
        /// <remarks>
        /// Checks can be added to ensure connection with the MongoDB according to the server
        /// </remarks>
        /// <returns>The MongoDB Client</returns>
        public static IMongoClient Connect()
        {         
            var Client = new MongoClient(ConfigurationManager.ConnectionStrings["MongoDB"].ConnectionString);
            return Client;
        }

        /// <summary>
        /// Gets a Database object for manipulation from the server and creates one if none exist
        /// </summary>
        /// <param name="Database">The Database name</param>
        /// <returns>Database Object</returns>
        public static IMongoDatabase GetDatabase(string Database)
        {
            return Connect().GetDatabase(Database);
        }

        /// <summary>
        /// Gets a Collection object for manipulation from the server and creates one if none exist
        /// </summary>
        /// <typeparam name="TDocument">Document Type to return the Collection (Usually BsonDocument)</typeparam>
        /// <param name="Database">The Database name</param>
        /// <param name="Collection">The Collection Name</param>
        /// <returns>The Collection Tempelate</returns>
        public static IMongoCollection<TDocument> GetCollection<TDocument>(string Database, string Collection)
        {
            return GetDatabase(Database).GetCollection<TDocument>(Collection);
        }
    }
}