using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MRF_Sample_Task.Models;

namespace MRF_Sample_Task.Controllers
{
    public class DetailsController : Controller
    {
        DetailsDb DetailsData = new DetailsDb();
        // GET: Details
        public ActionResult Details()
            Happy
        {
            return View();
        }
        public JsonResult List()
        {
            return Json(DetailsData.ListAll(), JsonRequestBehavior.AllowGet);
        }
        public JsonResult Delete(int id)
        {
            return Json(DetailsData.Delete(id), JsonRequestBehavior.AllowGet);
        }
        //public ActionResult Edit(int id)
        //{
        ////    ViewBag.id = id;
        //    return View("Index");
        //}
        public JsonResult Get(MRFModel emp)
        {
            return Json(DetailsData.Update(emp), JsonRequestBehavior.AllowGet);

        }
        public JsonResult GetbyID(int id)
        {
            var User = DetailsData.ListAll().Find(x => x.id.Equals(id));
            return Json(User, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Update(MRFModel emp)
        {
            return Json(DetailsData.Update(emp), JsonRequestBehavior.AllowGet);
        }
        
    }

}