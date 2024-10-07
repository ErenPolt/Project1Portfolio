using Project1Portfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project1Portfolio.Controllers
{
    public class ServicesController : Controller
    {
        myportfolioEntities context = new myportfolioEntities();
        
        //Services Tablosu Listeleme.
        public ActionResult ServicesList()
        {
            var values = context.Services.ToList();
            return View(values);
        }
        //----------------------------------------------------------------------------------------------
        //Services Tablosu Veri Ekleme:

        [HttpGet]
        public ActionResult CreateServices()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateServices(Services services)
        {
            context.Services.Add(services);
            context.SaveChanges();
            return RedirectToAction("ServicesList");
        }
        //------------------------------------------------------------------------------------------------------------
        //Servicess Tabllosu Veri Silme:

        public ActionResult DeleteServices(int id)
        {
            var value=context.Services.Find(id);
            context.Services.Remove(value);
            context.SaveChanges();
            return RedirectToAction("ServicesList");
        }
        //-------------------------------------------------------------------------------------------------------
        //Services Tablosu Veri Güncelleme:

        [HttpGet]
        public ActionResult UpdateServices(int id)
        {
            var value=context.Services.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateServices(Services services)
        {
            var value=context.Services.Find(services.Servicesİd);
            value.Title= services.Title;
            value.Description = services.Description;
            value.İcon= services.İcon;
            context.SaveChanges();
            return RedirectToAction("ServicesList");
        }
        //----------------------------------------------------------------------------------------------------------------------------
    }
}