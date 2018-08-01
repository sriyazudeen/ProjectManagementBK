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
    public class UserManagementController : ApiController
    {
        // GET: api/User
        [HttpGet]
        public IEnumerable<User> Get()
        {
            UserManagementBusinessLayer userManagementBL = new UserManagementBusinessLayer();
            return userManagementBL.GetAllUsers();
        }

        // GET: api/User/5
        [HttpGet]
        public User Get(int id)
        {
            UserManagementBusinessLayer userManagementBL = new UserManagementBusinessLayer();
            return userManagementBL.GetUser(id);
        }

        // POST: api/User
        [HttpPost]
        public string Post(User user)
        {
            UserManagementBusinessLayer userManagementBL = new UserManagementBusinessLayer();
            return userManagementBL.AddUser(user);
        }

        // PUT: api/User/5
        [HttpPut]
        public string Put(User user)
        {
            UserManagementBusinessLayer userManagementBL = new UserManagementBusinessLayer();
            return userManagementBL.EditUser(user);

        }

        // DELETE: api/User/5
        [HttpDelete]
        public string Delete(int id)
        {
            UserManagementBusinessLayer userManagementBL = new UserManagementBusinessLayer();
            return userManagementBL.DeleteUser(id);
        }
    }
}
