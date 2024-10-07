using Project1Portfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project1Portfolio.Controllers
{
    public class EducationController : Controller
    {
        myportfolioEntities context = new myportfolioEntities();
        public ActionResult EducationList()//Education Tablosu Listeleme
        {
            var values = context.Education.ToList();
            return View(values);
        }
        //---------------------------------------------------------------------------------------------------
       
        //EDucation Tablosu Veri Ekleme:

        [HttpGet]
        public ActionResult CreateEducation()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateEducation(Education education)
        {
            context.Education.Add(education);
            context.SaveChanges();
            return RedirectToAction("EducationList");
        }
        //--------------------------------------------------------------------------------------------------------

        //Education Tablosu Veri Silme:

        public ActionResult DeleteEducation(int id)
        {
            var value=context.Education.Find(id);
            context.Education.Remove(value);
            context.SaveChanges();
            return RedirectToAction("EducationList");
        }
        //------------------------------------------------------------------------------------------------------

        //Education Tablosu Güncelleme:

        [HttpGet]
        public ActionResult UpdateEducation(int id)
        {
            var value=context.Education.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateEducation(Education education)
        {
            var value = context.Education.Find(education.Educationİd);
            value.Title= education.Title;
            value.EducationDate= education.EducationDate;
            value.Subtitle= education.Subtitle; 
            value.Description= education.Description;
            context.SaveChanges();
            return RedirectToAction("EducationList");
        }
        //-----------------------------------------------------------------------------------------------------------------
    }
}