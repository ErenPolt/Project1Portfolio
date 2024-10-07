using Project1Portfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project1Portfolio.Controllers
{
    public class AboutController : Controller
    {
        myportfolioEntities context = new myportfolioEntities();
        public ActionResult AboutIndex()//About tablosunu listeleme:
        {
            var values = context.About.ToList();
            return View(values);
        }

        //-----------------------------------------------
        //About Tablosu Veri Ekleme:
        [HttpGet]
        public ActionResult CreateAbout()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateAbout(About about)
        {
            context.About.Add(about);
            context.SaveChanges();
            return RedirectToAction("AboutIndex");
        }
        //-------------------------------------------------------
        //About Tablosu  Veri Silme:
        public ActionResult DeleteAbout(int id)
        {
            var value = context.About.Find(id);
            context.About.Remove(value);
            context.SaveChanges();
            return RedirectToAction("AboutIndex");
        }
        //-----------------------------------------------------------
        //About Tablosu Güncelleme İşlemiş:

        [HttpGet]
        public ActionResult UpdateAbout(int id)
        {
            var value=context.About.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateAbout(About about)
        {
            var value = context.About.Find(about.Aboutİd);
            value.Title = about.Title;
            value.Detail=about.Detail;
            value.İmageUrl = about.İmageUrl;
            context.SaveChanges();
            return RedirectToAction("AboutIndex");
        }
        //---------------------------------------------------------
    }
}