using BookWebService.Models;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using System.Collections.Generic;

namespace BookWebService.Controllers.Database
{
    /// <summary>
    /// This Class deals with manipulation with user data from the databse
    /// </summary>
    public class UserDatabaseController
    {
        /// <summary>
        /// Checks if Username exists and that the password match it in the database
        /// </summary>
        /// <param name="Username">Username string</param>
        /// <param name="Password">Password string</param>
        /// <remarks>
        /// <para>Better to store salts (or any protection hashes) to prevent dictionary/rainbow attacks</para>
        /// <para>May change Return Type to specify error</para>
        /// </remarks>
        /// <returns>boolean</returns>
        public static bool Login(string Username, string Password)
        {
            var Collection = MongoDBController.GetCollection<BsonDocument>("Crossover", "User");
            var Filter = Builders<BsonDocument>.Filter.Eq("Username", Username);
            var list = Collection.Find(Filter).ToList();
            if (list.Count == 0)
                return false;
            return BsonSerializer.Deserialize<UserModel>(list[0]).Password == Password;
        }

        /// <summary>
        /// Registers a User in the database
        /// </summary>
        /// <param name="User">User Model</param>
        /// <remarks>
        /// <para>ID object exists but I didn't use it as MongoDB generates it </para>
        /// <para>Better to store salts (or any protection hashes) to prevent dictionary/rainbow attacks </para>
        /// <para>May change Return Type to specify error</para>
        /// </remarks>
        /// <returns>true if successful, false otherwise</returns>
        public static bool Register(UserModel User)
        {
            var Collection = MongoDBController.GetCollection<BsonDocument>("Crossover", "User");
            if (UserExists(User.Username))
                return false;
            Collection.InsertOne(User.ToBsonDocument(typeof(UserModel)));
            return true;
        }

        /// <summary>
        /// Checks if Username exists or not
        /// </summary>
        /// <param name="Username">Username string</param>
        /// <returns>boolean</returns>
        public static bool UserExists(string Username)
        {
            var Collection = MongoDBController.GetCollection<BsonDocument>("Crossover", "User");
            var Filter = Builders<BsonDocument>.Filter.Eq("Username", Username);
            if (Collection.Find(Filter).Count() > 0)
                return true;
            return false;
        }
    }
}