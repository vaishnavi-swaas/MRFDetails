using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MRF_Sample_Task.Models;

namespace MRF_Sample_Task.Controllers
{
    public class MRFController : Controller
    {
        MRF_Datalayer MRFDB = new MRF_Datalayer();
        

        public ActionResult Index(string Email)
        {
            ViewBag.Userid = Email; 
            return View();
        }
        public ActionResult Genernal()
        {
            return View();
        }

        public JsonResult Add(MRFModel MRF)
        {
            
            return Json(MRFDB.Add(MRF,ViewBag.Userid), JsonRequestBehavior.AllowGet);
        }
        public ActionResult Edit(int id, int edit)
        {
            ViewBag.Edit = edit;
            ViewBag.id = id;
            return View("index");
        }
        
    }
}