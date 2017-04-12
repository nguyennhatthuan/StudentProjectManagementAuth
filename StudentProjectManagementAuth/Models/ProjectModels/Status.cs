using StudentProjectManagementAuth.Definitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentProjectManagementAuth.Models
{
    public class Status : BaseEntity
    {
        public virtual ICollection<Group> Groups { get; set; }
    }
}