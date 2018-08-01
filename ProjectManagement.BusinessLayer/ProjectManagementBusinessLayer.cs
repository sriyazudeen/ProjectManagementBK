using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectManagement.Entities;
using ProjectManagement.DataLayer;
using System.Data.Entity;
namespace ProjectManagement.BusinessLayer
{
    public class ProjectManagementBusinessLayer
    {
        public List<Project> GetAllProjects()
        {
            ProjectManagementDbContext dbContext = new ProjectManagementDbContext();
            TaskManagementBusinessLayer taskBL = new TaskManagementBusinessLayer();
            foreach(Project project in dbContext.Projects.ToList())
            {
                project.TaskCount = taskBL.GetTaskCountByProject(project.ProjectID);
                project.CompletedTaskCount = taskBL.GetCompletedTaskCountByProject(project.ProjectID);
            }
            return dbContext.Projects.ToList();
        }

        public Project GetProject(int id)
        {
            ProjectManagementDbContext dbContext = new ProjectManagementDbContext();
            return dbContext.Projects.Where(p => p.ProjectID == id).FirstOrDefault();
        }

       
        public string AddProject(Project project)
        {
            ProjectManagementDbContext dbContext = new ProjectManagementDbContext();
            dbContext.Projects.Add(project);

            if (dbContext.SaveChanges() > 0)
            {
                return "Record added Successfully";
            }
            else
            {
                return "Failed. Plese try again later";
            }
        }

        public string EditProject(Project project)
        {
            ProjectManagementDbContext dbContext = new ProjectManagementDbContext();
            Project projectData = dbContext.Projects.Find(project.ProjectID);
            projectData.ProjectDesc = project.ProjectDesc;
            projectData.StartDate = project.StartDate;
            projectData.EndDate = project.EndDate;
            projectData.Priority = project.Priority;            

            if (dbContext.SaveChanges() > 0)
            {
                return "Record updated Successfully";
            }
            else
            {
                return "Failed. Plese try again later";
            }
        }

        public string DeleteProject(int id)
        {
            ProjectManagementDbContext dbContext = new ProjectManagementDbContext();
            Project project = dbContext.Projects.Find(id);
            dbContext.Projects.Remove(project);

            if (dbContext.SaveChanges() > 0)
            {
                return "Record deleted Successfully";
            }
            else
            {
                return "Failed. Plese try again later";
            }
        }

    }
}
