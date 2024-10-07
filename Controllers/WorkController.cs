using Project1Portfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project1Portfolio.Controllers
{
    public class WorkController : Controller
    {
        myportfolioEntities context = new myportfolioEntities();
        public ActionResult WorkList()//Work Tablosu Listeleme;
        {
            var values = context.Work.ToList();
            return View(values);
        }
        //---------------------------------------------------------------
        //Work Tablosu Veri Silme:
        public ActionResult DeleteWork(int id)
        {
            var values = context.Work.Find(id);
            context.Work.Remove(values);
            context.SaveChanges();
            return RedirectToAction("WorkList");
        }
        //-----------------------------------------------------------------------------
        //Work Tablosu Veri Ekleme:
        [HttpGet]
        public ActionResult CreateWork()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateWork(Work work)
        {
            context.Work.Add(work);
            context.SaveChanges();
            return RedirectToAction("WorkList");
        }
        //--------------------------------------------------------------------------
        //Work Tablosu Veri Güncelleme:
        [HttpGet]
        public ActionResult UpdateWork(int id)
        {
            var values = context.Work.Find(id);
            return View(values);
        }

        [HttpPost]
        public ActionResult UpdateWork(Work work)
        {
            var values = context.Work.Find(work.Worid);
            values.Title = work.Title;
            values.Description = work.Description;
            values.İmageUrl = work.İmageUrl;
            values.GithubUrl = work.GithubUrl;
            context.SaveChanges();
            return RedirectToAction("WorkList");
        }
        //-------------------------------------------------------------------------------
    }
}