using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StudentProjectManagementAuth.Areas.Administrator.Models;

namespace StudentProjectManagementAuth.Areas.Administrator.Controllers
{
    public class AdministratorController : Controller
    {
        // GET: Administrator/Administrator
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Dashboard()
        {
            return View();
        }

        #region Management Professor
        public ActionResult ProfessorManagement()
        {
            return View();
        }

        private Dictionary<string, string[]> ValidationMessageList
        {
            get
            {
                return ModelState
                .Where(x => x.Value.Errors.Count > 0)
                .ToDictionary(
                    kvp => kvp.Key,
                    kvp => kvp.Value.Errors.Select(e => e.ErrorMessage).ToArray()
                );
            }
        }

        private List<ProfessorModel> Init()
        {
            List<ProfessorModel> list = new List<ProfessorModel>();
            list.Add(new ProfessorModel()
            {
                UserName = "congthanh"
            });
            list.Add(new ProfessorModel()
            {
                UserName = "bichdao"
            });
            list.Add(new ProfessorModel()
            {
                UserName = "lynhaky"
            });

            return list;
        }

        [HttpPost]
        public JsonResult DeleteProfessor(ProfessorModel model)
        {
            bool status = true;
            List<ProfessorModel> list = Init();
            string error = string.Empty;

            try
            {
                list.Remove(model);
            }
            catch (Exception ex)
            {
                error = ex.Message;
                status = false;
            }

            return Json(new
            {
                Status = status,
                Message = status ? "Data was saved successfully" : "Failed to save data",
                List = list
            });
        }

        [HttpGet]
        public JsonResult LoadAllProfessor()
        {
            // Init Data
            List<ProfessorModel> professors = Init();
            int totalCount = professors.Count;

            return Json(new
            {
                Professors = professors,
                TotalCount = totalCount
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult CreateProfessor(ProfessorModel model)
        {
            // Init Data
            List<ProfessorModel> professors = Init();

            bool status = true;

            if (string.IsNullOrEmpty(model.UserName))
            {
                ModelState.AddModelError("UserName", "Username is empty");
                status = false;
            }

            if (string.IsNullOrEmpty(model.Password))
            {
                ModelState.AddModelError("Password", "Password is empty");
                status = false;
            }

            if (string.IsNullOrEmpty(model.ConfirmPassword))
            {
                ModelState.AddModelError("ConfirmPassword", "ConfirmPassword is empty");
                status = false;
            }

            if (string.IsNullOrEmpty(model.UserName) == false && model.UserName.Length < 6 | model.UserName.Length > 15)
            {
                ModelState.AddModelError("UserName", "Username is 6 to 15 characters long");
                status = false;
            }

            if (string.IsNullOrEmpty(model.UserName) == false && professors.Exists(p => p.UserName == model.UserName))
            {
                ModelState.AddModelError("UserName", "Username is existed");
                status = false;
            }

            if (string.IsNullOrEmpty(model.Password) == false && model.Password.Length < 6 | model.Password.Length > 30)
            {
                ModelState.AddModelError("Password", "Password is 6 to 30 characters long");
                status = false;
            }

            if (string.IsNullOrEmpty(model.Password) == false && string.IsNullOrEmpty(model.ConfirmPassword) == false && model.ConfirmPassword != model.Password)
            {
                ModelState.AddModelError("ConfirmPassword", "ConfirmPassword inconrect");
                status = false;
            }

            if (status)
            {
                professors.Add(model);
            }

            var professor = professors.FirstOrDefault(p => p.UserName == model.UserName);

            return Json(new
            {
                Status = status,
                Message = status ? "Data was saved successfully" : "Failed to save data",
                Model = professor,
                ValiValidationMessage = this.ValidationMessageList
            });
        }

        #endregion
    }
}