using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace StudentProjectManagementAuth.Models
{
    public class Student
    {
        [Key]
        public string CardNumber { get; set; }
        public string UserId { get; set; }
        public string College { get; set; }
        public string BEPercentage { get; set; }
        public string Knowledge { get; set; }
        public string PriorExperience { get; set; }
        public string GroupId { get; set; }

        [ForeignKey("UserId")]
        public virtual ApplicationUser User { get; set; }

        [ForeignKey("GroupId")]
        public virtual Group Group { get; set; }
    }
}