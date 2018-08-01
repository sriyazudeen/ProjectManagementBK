using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using ProjectManagementBK.Controllers;
using System.Net.Http;
using System.Web.Http;
using ProjectManagement.Entities;
namespace ProjectManagement.Test
{
    [TestFixture]
    public class UserManagementAPITest
    {
        [TestCase]
        public void GetAllUsersTest()
        {

            var controller = new UserManagementController();
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            var response = controller.Get();



            Assert.IsNotEmpty(response);

        }
        [TestCase]
        public void GetUserTest()
        {
            var controller = new UserManagementController();
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            var response = controller.Get(1);

            Assert.AreEqual(response.UserID, 1);
            Assert.AreEqual("Riyaz", response.FirstName);
        }
        [TestCase]
        public void AddUserTest()
        {
            var controller = new UserManagementController();
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            User user = new User();
            user.EmployeeID = 3412342;
            user.FirstName = "Test Test";
            user.LastName = "Test";
            

            string result = controller.Post(user);
            Assert.AreEqual("Record added Successfully", result);
        }
        [TestCase]
        public void UpdateUserTest()
        {
            var controller = new UserManagementController();
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            var user = controller.Get(1);
            user.EmployeeID = 456789;

            string result = controller.Put(user);
            Assert.AreEqual("Record updated Successfully", result);

        }
        [TestCase]
        public void DeleteUserTest()
        {
            var controller = new ProjectManagementController();
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            string result = controller.Delete(3);
            Assert.AreEqual("Record deleted Successfully", result);
        }
    }
}
