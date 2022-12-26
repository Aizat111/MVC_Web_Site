using FinalHomeWork.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class AdminController: Controller
    {
        EmployeesInfoEntities1 db = new EmployeesInfoEntities1();
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(admins avm)
        {
            admins ad = db.admins.Where(x => x.user_name == avm.user_name && x.password == avm.password).SingleOrDefault();
            if (ad != null)
            {

                Session["id"] = ad.id.ToString();
                return RedirectToAction("JobsList", "Home");

            }
            else
            {
                ViewBag.error = "Invalid username or password";

            }

            return View();
        }
    }
}