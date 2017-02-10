using BookWebService.Controllers.Database;
using BookWebService.Models;
using System.Collections.Generic;
using System.Web.Http;

namespace BookWebService.Controllers.WebAPI
{
    /// <summary>
    /// User Web Controller
    /// </summary>
    [RoutePrefix("api/User")]
    public class UserWebController : ApiController
    {
        /// <summary>
        /// Logs the User in
        /// </summary>
        /// <param name="Username">Username String</param>
        /// <param name="Password">Password String</param>
        /// <returns>true if successful, false otherwise</returns>
        [HttpGet]
        [Route("Login")]
        public bool Login([FromUri]string Username, [FromUri]string Password)
        {
            return UserDatabaseController.Login(Username, Password);
        }

        /// <summary>
        /// Register The User
        /// </summary>
        /// <param name="Username">Username</param>
        /// <param name="Password">Password</param>
        /// <param name="Library">Library</param>
        /// <returns>true if successful, false otherwise</returns>
        [HttpGet]
        [Route("Register")]
        public bool Register([FromUri]string Username, [FromUri]string Password, [FromUri]string Library)
        {
            var value = new UserModel()
            {
                Username = Username,
                Password = Password,
                Library = Library
            };
            return UserDatabaseController.Register(value);
        }

        /// <summary>
        /// View user demands
        /// </summary>
        /// <param name="Username">Username</param>
        /// <returns>A list of Demands</returns>
        [HttpGet]
        [Route("Demands")]
        public List<DemandModel> Demands([FromUri]string Username)
        {
            return DemandDatabaseController.ViewDemands(Username);
        }    
    }
}
