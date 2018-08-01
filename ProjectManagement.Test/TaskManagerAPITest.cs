using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using ProjectManagementBK.Controllers;
using System.Net.Http;
using System.Web.Http;
using ProjectManagement.Entities;

namespace ProjectManagement.Test
{
    [TestFixture]
    public class TaskManagerAPITest
    {

        
        [TestCase]
        public void GetAllTasksTest()
        {

            var controller = new TaskManagerController();
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            var response = controller.Get();



            Assert.IsNotEmpty(response);

        }
        [TestCase]
        public void GetTaskTest()
        {
            var controller = new TaskManagerController();
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            var response = controller.Get(1);

            Assert.AreEqual(response.TaskID, 1);
            Assert.AreEqual("Sample Task Parent 1", response.TaskDesc);
        }
        [TestCase]
        public void AddTaskTest()
        {
            var controller = new TaskManagerController();
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            Task task = new Task();
            task.TaskDesc = "NUnit Task";
            task.Priority = 10;
            task.ProjectID = 1;
            task.StartDate = Convert.ToDateTime("2018-06-01");
            task.EndDate = Convert.ToDateTime("2018-06-30");
            task.ParentTaskID = 1;

            string result = controller.AddTask(task);
            Assert.AreEqual("Record added Successfully", result);
        }
        [TestCase]
        public void UpdateTaskTest()
        {
            var controller = new TaskManagerController();
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            var task = controller.Get(1);
            task.Priority = 15;

            string result = controller.EditTask(task);
            Assert.AreEqual("Record updated Successfully", result);

        }
        [TestCase]
        public void DeleteTaskTest()
        {
            var controller = new TaskManagerController();
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();           

            string result = controller.DeleteTask(9);
            Assert.AreEqual("Record deleted Successfully", result);
        }

        [TestCase]
        public void GetAllParentTasksTest()
        {

            var controller = new ParentTaskManagerController();
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            var response = controller.GetAllParentTasks();



            Assert.IsNotEmpty(response);

        }

        
    }
}
