using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ATP2_MVC.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            // return RedirectToAction("MyMethod", new { id});

            return View();
        }

        [HttpPost]
        public ActionResult Index(int? id)
        {
            // return RedirectToAction("MyMethod", new { id});

            if (Request["agree"] == "on")
            {
                if (Request["password"] == Request["confirmPassword"])
                {
                    return View("Data");
                }
                else
                {
                    ViewData["msg"] = "Password and Confirm Password are not matching.";
                    return View();
                }
            }
            else
            {
                ViewData["msg"] = "Please agree with our terms and condition.";
                return View();
            }
        }
    }
}