using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProjectManagement.Entities
{
    public class ParentTask
    {

        public ParentTask()
        {
            Tasks = new HashSet<Task>();
        }

        [Key()]
        public int ParentTaskID
        {
            get;
            set;
        }

        public string ParentTaskDesc
        {
            get;
            set;
        }

        public virtual ICollection<Task> Tasks
        {
            get;
            set;
        }
    }
}
