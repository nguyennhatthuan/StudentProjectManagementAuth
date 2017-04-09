using Microsoft.AspNet.Identity.EntityFramework;
using StudentProjectManagementAuth.Definitions;
using System;
using System.Web.Mvc;

namespace StudentProjectManagementAuth.Areas.Administrator.Controllers
{
    public class ManageRoleController : Controller
    {
        private Repository<IdentityRole> _roleDb;  
        public ManageRoleController()
        {
            _roleDb = new Repository<IdentityRole>();
        }

        // GET: Administrator/ManageRole
        public ActionResult Index()
        {
            var model = _roleDb.SelectAll();
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
                    _roleDb.Add(role);
                    _roleDb.Save();
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            return View(role);
        }

        public ActionResult Delete(string id)
        {
            var model = _roleDb.SelectById(id);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(string id)
        {
            IdentityRole model = null;
            try
            {
                model = _roleDb.SelectById(id);
                _roleDb.Delete(model);
                _roleDb.Save();
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