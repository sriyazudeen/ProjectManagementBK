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
    public class ProjectManagementAPITest
    {
        [TestCase]
        public void GetAllProjectsTest()
        {

            var controller = new ProjectManagementController();
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            var response = controller.Get();



            Assert.IsNotEmpty(response);

        }
        [TestCase]
        public void GetProjectTest()
        {
            var controller = new ProjectManagementController();
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            var response = controller.Get(1);

            Assert.AreEqual(response.ProjectID, 1);
            Assert.AreEqual("Test Project", response.ProjectDesc);
        }
        [TestCase]
        public void AddProjectTest()
        {
            var controller = new ProjectManagementController();
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            Project project = new Project();
            project.ProjectDesc = "NUnit Project";
            project.Priority = 10;
            project.ProjectID = 3;
            project.StartDate = Convert.ToDateTime("2018-06-01");
            project.EndDate = Convert.ToDateTime("2018-06-30");
            

            string result = controller.Post(project);
            Assert.AreEqual("Record added Successfully", result);
        }
        [TestCase]
        public void UpdateProjectTest()
        {
            var controller = new ProjectManagementController();
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            var project = controller.Get(1);
            project.Priority = 15;

            string result = controller.Put(project);
            Assert.AreEqual("Record updated Successfully", result);

        }
        [TestCase]
        public void DeleteProjectTest()
        {
            var controller = new ProjectManagementController();
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            string result = controller.Delete(7);
            Assert.AreEqual("Record deleted Successfully", result);
        }        
    }
}
