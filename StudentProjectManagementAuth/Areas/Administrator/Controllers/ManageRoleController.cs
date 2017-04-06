using Microsoft.AspNet.Identity.EntityFramework;
using StudentProjectManagementAuth.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentProjectManagementAuth.Areas.Administrator.Controllers
{
    public class ManageRoleController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Administrator/ManageRole
        public ActionResult Index()
        {
            var model = db.Roles.AsEnumerable();
            return View(model);
        }

        public ViewResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IdentityRole role)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Roles.Add(role);
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            return View(role);
        }

        public ActionResult Delete(string Id)
        {
            var model = db.Roles.Find(Id);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(string Id)
        {
            IdentityRole model = null;
            try
            {
                model = db.Roles.Find(Id);
                db.Roles.Remove(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            return View(model);
        }
    }
}