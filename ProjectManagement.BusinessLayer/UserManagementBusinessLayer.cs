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
    public class UserManagementBusinessLayer
    {
        public List<User> GetAllUsers()
        {
            ProjectManagementDbContext dbContext = new ProjectManagementDbContext();
            return dbContext.Users.ToList();
        }

        public User GetUser(int id)
        {
            ProjectManagementDbContext dbContext = new ProjectManagementDbContext();
            return dbContext.Users.Where(u => u.UserID == id).FirstOrDefault();
        }


        public string AddUser(User user)
        {
            ProjectManagementDbContext dbContext = new ProjectManagementDbContext();
            dbContext.Users.Add(user);

            if (dbContext.SaveChanges() > 0)
            {
                return "Record added Successfully";
            }
            else
            {
                return "Failed. Plese try again later";
            }
        }

        public string EditUser(User user)
        {
            ProjectManagementDbContext dbContext = new ProjectManagementDbContext();
            User userData = dbContext.Users.Find(user.UserID);
            userData.FirstName = user.FirstName;
            userData.LastName = user.LastName;
            userData.EmployeeID = user.EmployeeID;            

            if (dbContext.SaveChanges() > 0)
            {
                return "Record updated Successfully";
            }
            else
            {
                return "Failed. Plese try again later";
            }
        }

        public string DeleteUser(int id)
        {
            ProjectManagementDbContext dbContext = new ProjectManagementDbContext();
            User user = dbContext.Users.Find(id);
            dbContext.Users.Remove(user);

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
