using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjectManagement.Entities;
using System.Data.Entity;
using ProjectManagement.BusinessLayer;
using ProjectManagement.DataLayer;
namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ProjectManagementDbContext model = new ProjectManagementDbContext())
            {

                Project project = new Project();
                project.ProjectID = 1;
                project.ProjectDesc = "Test Project";
                project.StartDate = Convert.ToDateTime("01/01/2017");
                project.EndDate = Convert.ToDateTime("31/12/2018");
                project.Priority = 10;
                project.ProjectManager = 1;
                model.Projects.Add(project);

                project = new Project();
                project.ProjectID = 2;
                project.ProjectDesc = "Sample Project";
                project.StartDate = Convert.ToDateTime("01/01/2018");
                project.EndDate = Convert.ToDateTime("31/12/2018");
                project.Priority = 15;
                project.ProjectManager = 2;
                model.Projects.Add(project);


                ParentTask parentTask = new ParentTask();
                parentTask.ParentTaskID = 1;
                parentTask.ParentTaskDesc = "Parent 1";

                List<Task> taskList = new List<Task>();

                Task task = new Task();
                task.TaskID = 1;
                task.ParentTaskID = 1;
                task.ProjectID = 1;
                task.StartDate = Convert.ToDateTime("27/06/2018");
                task.EndDate = Convert.ToDateTime("29/06/2018");
                task.TaskDesc = "Sample Task Parent 1";
                task.Priority = 10;
                task.TaskOwner = 1;
                taskList.Add(task);


                task = new Task();
                task.TaskID = 2;
                task.ParentTaskID = 1;
                task.ProjectID = 1;
                task.StartDate = Convert.ToDateTime("20/06/2018");
                task.EndDate = Convert.ToDateTime("25/06/2018");
                task.TaskDesc = "This is test task Parent 1";
                task.Priority = 20;
                task.TaskOwner = 1;
                taskList.Add(task);


                task = new Task();
                task.TaskID = 3;
                task.ParentTaskID = 1;
                task.ProjectID = 1;
                task.StartDate = Convert.ToDateTime("27/06/2018");
                task.EndDate = Convert.ToDateTime("29/06/2018");
                task.TaskDesc = "Test Task Parent 1";
                task.Priority = 5;
                task.TaskOwner = 2;
                taskList.Add(task);

                parentTask.Tasks = taskList;

                model.ParentTasks.Add(parentTask);

                parentTask = new ParentTask();
                parentTask.ParentTaskID = 2;
                parentTask.ParentTaskDesc = "Parent 2";

                taskList = new List<Task>();

                task = new Task();
                task.TaskID = 4;
                task.ParentTaskID = 2;
                task.ProjectID = 2;
                task.StartDate = Convert.ToDateTime("27/04/2018");
                task.EndDate = Convert.ToDateTime("29/06/2018");
                task.TaskDesc = "Sample Task parent 2";
                task.Priority = 15;
                task.TaskOwner = 2;
                taskList.Add(task);


                task = new Task();
                task.TaskID = 5;
                task.ParentTaskID = 2;
                task.ProjectID = 2;
                task.StartDate = Convert.ToDateTime("20/03/2018");
                task.EndDate = Convert.ToDateTime("25/05/2018");
                task.TaskDesc = "This is test task Parent 2";
                task.Priority = 21;
                task.TaskOwner = 1;
                taskList.Add(task);


                task = new Task();
                task.TaskID = 6;
                task.ParentTaskID = 2;
                task.ProjectID = 2;
                task.StartDate = Convert.ToDateTime("27/06/2018");
                task.EndDate = Convert.ToDateTime("29/09/2018");
                task.TaskDesc = "Test Task Parent 2";
                task.Priority = 30;
                taskList.Add(task);

                parentTask.Tasks = taskList;

                model.ParentTasks.Add(parentTask);

                User user = new User();
                user.UserID = 1;
                user.FirstName = "Riyaz";
                user.LastName = "S";
                user.EmployeeID = 123456;
                

                model.Users.Add(user);

                user = new User();
                user.UserID = 2;
                user.FirstName = "Sam";
                user.LastName = "Troy";
                user.EmployeeID = 423423;
                

                model.Users.Add(user);

                model.SaveChanges();
            }
            //TaskManagerBusinessLayer businessLayer = new TaskManagerBusinessLayer();
            //List<Task> taskList = businessLayer.GetAllTasks();

            //Task task = businessLayer.GetTask(1);
            
            

        }
    }
}
