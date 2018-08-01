using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProjectManagement.Entities
{
    public class User
    {
        [Key()]
        public int UserID
        {
            get;
            set;
        }


        [Required(ErrorMessage = "FirstName Required")]
        public string FirstName
        {
            get;
            set;
        }

        [Required(ErrorMessage = "LastName Required")]
        public string LastName
        {
            get;
            set;
        }

        [Required(ErrorMessage = "Employeed ID Required")]
        public int EmployeeID
        {
            get;
            set;
        }        
    }
}
