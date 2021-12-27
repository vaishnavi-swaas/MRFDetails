using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MRF_Sample_Task.Models;

namespace MRF_Sample_Task.Controllers
{
    public class SampleController : Controller
    {
        LoginDb LoginDB = new LoginDb();
        // GET: Sample
        public ActionResult Index ()
        {
            return View();
        }
        public JsonResult Login(string Email, string Password)
        {
            ViewBag.Userid = Email;
            return Json(LoginDB.Login(Email, Password), JsonRequestBehavior.AllowGet);
        
        }
        
    }
}