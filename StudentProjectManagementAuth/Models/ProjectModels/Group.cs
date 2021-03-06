﻿using StudentProjectManagementAuth.Definitions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace StudentProjectManagementAuth.Models
{
    public class Group : BaseEntity
    {
        public int MemberCount { get; set; } = 0;
        public string StatusId { get; set; }

        [ForeignKey("StatusId")]
        public virtual Status Status { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}