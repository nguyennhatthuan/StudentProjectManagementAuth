using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentProjectManagementAuth.Areas.Administrator.Models
{
    public class ProfessorModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}