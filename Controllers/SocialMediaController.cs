using Project1Portfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project1Portfolio.Controllers
{
    public class SocialMediaController : Controller
    {
        myportfolioEntities context=new myportfolioEntities();
        public ActionResult SocialMediaList()//SocialMedia Tablosu Listeleme:
        {
            var values = context.SocialMedia.ToList();
            return View(values);
        }
        //-----------------------------------------------------------------------------------
        //SocialMedia Tablosu Aktif/Pasif Yapma:
        public ActionResult StatusChangeToTrue(int id)
        {
            var value = context.SocialMedia.Where(x => x.SocialMediaId == id).FirstOrDefault();
            value.Status = true;
            context.SaveChanges();
            return RedirectToAction("SocialMediaList");
        }

        public ActionResult StatusChangeToFalse(int id)
        {
            var value = context.SocialMedia.Where(x => x.SocialMediaId == id).FirstOrDefault();
            value.Status = false;
            context.SaveChanges();
            return RedirectToAction("SocialMediaList");
        }
        //-------------------------------------------------------------------------------------------
        //SocialMedia Tablosu Veri Ekleme:
        [HttpGet]
        public ActionResult CreateSocialMedia()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateSocialMedia(SocialMedia socialMedia)
        {
            context.SocialMedia.Add(socialMedia);
            context.SaveChanges();
            return RedirectToAction("SocialMediaList");
        }
        //-------------------------------------------------------------------------------------------------
        //SocialMedia Tablosu Veri Güncelleme:
        [HttpGet]
        public ActionResult UpdateSocialMedia(int id)
        {
            var value = context.SocialMedia.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateSocialMedia(SocialMedia socialmedia)
        {
            var values = context.SocialMedia.Find(socialmedia.SocialMediaId);
            values.Title= socialmedia.Title;
            values.Icon= socialmedia.Icon;
            values.Status = socialmedia.Status;
            context.SaveChanges();
            return RedirectToAction("SocialMediaList");
        }
        //------------------------------------------------------------------------------------------
    }
}