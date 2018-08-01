using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProjectManagement.Entities
{
    public class Project
    {
        [Key()]
        public int ProjectID
        {
            get;
            set;
        }
        

        [Required(ErrorMessage = "Project Desc Required")]
        public string ProjectDesc
        {
            get;
            set;
        }

        [Required(ErrorMessage = "StartDate Required")]
        [DataType(DataType.DateTime, ErrorMessage = "Invalid DateTime")]
        public DateTime StartDate
        {
            get;
            set;
        }
        [Required(ErrorMessage = "EndDate Required")]
        [DataType(DataType.DateTime, ErrorMessage = "Invalid DateTime")]
        public DateTime EndDate
        {
            get;
            set;
        }
        [Required(ErrorMessage = "Priority Required")]
        [Range(0, 30, ErrorMessage = "Invalid Range")]
        public int Priority
        {
            get;
            set;
        } 
        [ForeignKey("User")]
        public int? ProjectManager
        {
            get;
            set;
        }
        
        [NotMapped]
        public int TaskCount
        {
            get;
            set;
        }

        [NotMapped]
        public int CompletedTaskCount
        {
            get;
            set;
        }
        public virtual User User { get; set; }
    }
}
