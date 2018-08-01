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
    public class ProjectManagementController : ApiController
    {
        // GET: api/ProjectManagement
        [HttpGet]
        public IEnumerable<Project> Get()
        {
            ProjectManagementBusinessLayer projectManagementBL = new ProjectManagementBusinessLayer();
            return projectManagementBL.GetAllProjects();
        }

        // GET: api/ProjectManagement/5
        [HttpGet]
        public Project Get(int id)
        {
            ProjectManagementBusinessLayer projectManagementBL = new ProjectManagementBusinessLayer();
            return projectManagementBL.GetProject(id);
        }

        // POST: api/ProjectManagement
        [HttpPost]
        public string Post(Project project)
        {
            ProjectManagementBusinessLayer projectManagementBL = new ProjectManagementBusinessLayer();
            return projectManagementBL.AddProject(project);
        }

        // PUT: api/ProjectManagement/5
        [HttpPut]
        public string Put(Project project)
        {
            ProjectManagementBusinessLayer projectManagementBL = new ProjectManagementBusinessLayer();
            return projectManagementBL.EditProject(project);
        }

        // DELETE: api/ProjectManagement/5
        [HttpDelete]
        public string Delete(int id)
        {
            ProjectManagementBusinessLayer projectManagementBL = new ProjectManagementBusinessLayer();
            return projectManagementBL.DeleteProject(id);
        }
    }
}
