using Project1Portfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project1Portfolio.Controllers
{
    public class AdminController : Controller
    {
        myportfolioEntities context = new myportfolioEntities();
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult PartialHead()
        {
            return PartialView();
        }
        public PartialViewResult PartialSideBar()
        {
            ViewBag.imageUrl = context.About.Select(x => x.İmageUrl).FirstOrDefault();
            return PartialView();
        }
        public PartialViewResult PartialNavBar()
        {
            return PartialView();
        }

        public ActionResult CvIndir()
        {
            // Dosya yolunu kontrol edin
            var filePath = Server.MapPath("~/Content/images/Ataturk.JPG");

            // Eğer dosya yoksa bir hata döndür
            if (!System.IO.File.Exists(filePath))
            {
                return HttpNotFound("Dosya bulunamadı.");
            }

            var fileName = "Ataturk.JPG";
            var contentType = "image/jpeg";

            // Dosya indirilebilir olarak döndür
            return File(filePath, contentType, fileName);

        }
    }
}