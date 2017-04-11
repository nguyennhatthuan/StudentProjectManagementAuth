using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace StudentProjectManagementAuth.Models
{
    public class ProjectDetails
    {
        [Key]
        [Column(Order = 0)]
        public string ProjectId { get; set; }
        [Key]
        [Column(Order = 1)]
        public string GroupId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        [ForeignKey("ProjectId")]
        public virtual Project Project { get; set; }
        [ForeignKey("GroupId")]
        public virtual Group Group { get; set; }
    }
}