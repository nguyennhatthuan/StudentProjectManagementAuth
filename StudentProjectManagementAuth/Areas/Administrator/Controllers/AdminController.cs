﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentProjectManagementAuth.Areas.Administrator.Controllers
{
    public class AdminController : Controller
    {
        // GET: Administrator/Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Dashboard()
        {
            return View();
        }
    }
}