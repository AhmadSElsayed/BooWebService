using BookWebService.Controllers.Database;
using MongoDB.Bson;
using System.Collections.Generic;
using System.Web.Http;

namespace BookWebService.Controllers.WebAPI
{
    /// <summary>
    /// Demands Web Controller
    /// </summary>
    [RoutePrefix("api/Demands")]
    public class DemandsWebController : ApiController
    {
        /// <summary>
        /// Make A demand
        /// </summary>
        /// <param name="ID">Book ID</param>
        /// <param name="Username">Username</param>
        /// <returns>true if successful, false Otherwise</returns>
        [Route("Create")]
        [HttpGet]
        public bool CreateDemand([FromUri]string ID, [FromUri]string Username)
        {
            var Book = new ObjectId(ID);
            return DemandDatabaseController.CreateDemand(Book, Username);
        }
    }
}
