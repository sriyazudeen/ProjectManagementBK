using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ProjectManagement.Entities;
using ProjectManagement.BusinessLayer;

namespace ProjectManagementBK.Controllers
{
    public class TaskManagerController : ApiController
    {
        // GET: api/TaskManager
        [HttpGet]
        public IEnumerable<Task> Get()
        {
            TaskManagementBusinessLayer businessLayer = new TaskManagementBusinessLayer();
            return businessLayer.GetAllTasks();
        }

        // GET: api/TaskManager/5
        [HttpGet]
        public Task Get(int id)
        {
            TaskManagementBusinessLayer businessLayer = new TaskManagementBusinessLayer();
            return businessLayer.GetTask(id);
        }
        

        // POST: api/TaskManager
        [HttpPost]
        public string AddTask(Task task)
        {
            TaskManagementBusinessLayer businessLayer = new TaskManagementBusinessLayer();
            return businessLayer.AddTask(task);
            
        }
        

        // PUT: api/TaskManager/5
        [HttpPut]
        public string EditTask(Task task)
        {
            TaskManagementBusinessLayer businessLayer = new TaskManagementBusinessLayer();
            return businessLayer.EditTask(task);
        }

        // DELETE: api/TaskManager/5
        [HttpDelete]
        public string DeleteTask(int id)
        {
            TaskManagementBusinessLayer businessLayer = new TaskManagementBusinessLayer();
            return businessLayer.DeleteTask(id);
        }
    }
}
