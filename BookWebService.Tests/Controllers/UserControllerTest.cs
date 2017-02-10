using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BookWebService;
using BookWebService.Controllers;
using BookWebService.Controllers.WebAPI;
using BookWebService.Controllers.Database;

namespace BookWebService.Tests.Controllers
{
    [TestClass]
    public class UserWebControllerTest
    {
        [TestMethod]
        public void Login(string Username, string Password)
        {
            UserWebController controller = new UserWebController();
            
            bool result = controller.Login(Username, Password);

            Assert.IsNotNull(result);
            Assert.AreEqual(result, UserDatabaseController.Login(Username,Password));
        }
        
        [TestMethod]
        public void Demands(string Username)
        {
            UserWebController controller = new UserWebController();

            var result = controller.Demands(Username);

            Assert.IsNotNull(result);
            Assert.AreEqual(result, DemandDatabaseController.ViewDemands(Username));

        }
    }
}
