using BookWebService.Controllers.Database;
using BookWebService.Models;
using MongoDB.Bson;
using System.Collections.Generic;
using System.Web.Http;

namespace BookWebService.Controllers.WebAPI
{
    /// <summary>
    /// Book Web Controller
    /// </summary>
    [RoutePrefix("api/Book")]
    public class BookWebController : ApiController
    {
        /// <summary>
        /// Gets All books
        /// </summary>
        /// <returns>List of Book Model</returns>
        [HttpGet]
        [Route("Get")]
        public List<BookModel> GetAll()
        {
            return BookDatabaseController.GetAll();
        }

        /// <summary>
        /// Get a Book
        /// </summary>
        /// <param name="Field">0 for Publishers, 1 for Title, 2 for ID</param>
        /// <param name="Search">Data to search by</param>
        /// <returns>List of Books</returns>
        [HttpGet]
        [Route("Search")]
        public List<BookModel> GetBook([FromUri]BookSearch Field, [FromUri]string Search)
        {
            return BookDatabaseController.GetBook(Field, Search);
        }

        /// <summary>
        /// Checks if a book exists
        /// </summary>
        /// <param name="ID">Book ID to search by</param>
        /// <returns>Boolean</returns>
        [HttpGet]
        [Route("Find")]
        public bool BookExists([FromUri]string ID)
        {
            var Book = new ObjectId(ID);
            return BookDatabaseController.BookExists(Book);
        }
    }
}
