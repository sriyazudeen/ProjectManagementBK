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
    public class ParentTaskManagerController : ApiController
    {
        public List<ParentTask> GetAllParentTasks()
        {
            TaskManagementBusinessLayer businessLayer = new TaskManagementBusinessLayer();
            return businessLayer.GetAllParentTasks();
        }

        [HttpPost]
        public string AddParentTask(ParentTask task)
        {
            TaskManagementBusinessLayer businessLayer = new TaskManagementBusinessLayer();
            return businessLayer.AddParentTask(task);

        }


    }
}
