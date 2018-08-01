using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjectManagement.Entities;
using ProjectManagement.DataLayer;
using System.Data.Entity;
namespace ProjectManagement.BusinessLayer
{
    public class TaskManagementBusinessLayer
    {
        public List<Task> GetAllTasks()
        {
            ProjectManagementDbContext dbContext = new ProjectManagementDbContext();            
            return dbContext.Tasks.Include(p=>p.ParentTask).Include(p=>p.Project).ToList();
        }

        public Task GetTask(int id)
        {
            ProjectManagementDbContext dbContext = new ProjectManagementDbContext();
            return dbContext.Tasks.Include("ParentTask").Include("Project").Where(t => t.TaskID == id).FirstOrDefault();
        }

        public List<ParentTask> GetAllParentTasks()
        {
            ProjectManagementDbContext dbContext = new ProjectManagementDbContext();
            return dbContext.ParentTasks.Distinct<ParentTask>().ToList();
        }

        public int GetTaskCountByProject(int id)
        {
            ProjectManagementDbContext dbContext = new ProjectManagementDbContext();
            return dbContext.Tasks.Where(t => t.ProjectID == id).Count();
        }

        public int GetCompletedTaskCountByProject(int id)
        {
            ProjectManagementDbContext dbContext = new ProjectManagementDbContext();
            return dbContext.Tasks.Where(t => t.ProjectID == id && t.TaskStatus == true).Count();
        }

        public string AddTask(Task task)
        {
            ProjectManagementDbContext dbContext = new ProjectManagementDbContext();
            dbContext.Tasks.Add(task);                     

            if(dbContext.SaveChanges() > 0)
            {
                return "Record added Successfully";
            }
            else
            {
                return "Failed. Plese try again later";
            }
        }

        public string AddParentTask(ParentTask task)
        {
            ProjectManagementDbContext dbContext = new ProjectManagementDbContext();
            dbContext.ParentTasks.Add(task);

            if (dbContext.SaveChanges() > 0)
            {
                return "Record added Successfully";
            }
            else
            {
                return "Failed. Plese try again later";
            }
        }

        public string EditTask(Task task)
        {
            ProjectManagementDbContext dbContext = new ProjectManagementDbContext();
            Task taskData = dbContext.Tasks.Find(task.TaskID);
            taskData.TaskDesc = task.TaskDesc;
            taskData.StartDate = task.StartDate;
            taskData.EndDate = task.EndDate;
            taskData.Priority = task.Priority;            
            taskData.TaskStatus = task.TaskStatus;
            taskData.TaskOwner = task.TaskOwner;

            if (dbContext.SaveChanges() > 0)
            {
                return "Record updated Successfully";
            }
            else
            {
                return "Failed. Plese try again later";
            }
        }

        public string  DeleteTask(int id)
        {
            ProjectManagementDbContext dbContext = new ProjectManagementDbContext();
            Task task = dbContext.Tasks.Find(id);
            dbContext.Tasks.Remove(task);

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
