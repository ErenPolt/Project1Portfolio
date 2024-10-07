using Project1Portfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project1Portfolio.Controllers
{
    public class ProfileController : Controller
    {
        myportfolioEntities context = new myportfolioEntities();
        
        public ActionResult ProfileList()//Profile Tablosu Listeleme..
        {
            var values = context.Profile.ToList();
            return View(values);
        }
        //-----------------------------------------------------------------------------------------

        //Profile Tablosu Veri Ekleme:

        [HttpGet]
        public ActionResult CreateProfile()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateProfile(Profile profile)
        {
            context.Profile.Add(profile);
            context.SaveChanges();
            return RedirectToAction("ProfileList");
        }
        //------------------------------------------------------------------------------------------

        //Profile Tablosu Veri Silme:

        public ActionResult DeleteProfile(int id)
        {
            var value = context.Profile.Find(id);
            context.Profile.Remove(value);
            context.SaveChanges();
            return RedirectToAction("ProfileList");
        }
        //-------------------------------------------------------------------------------------------

        //ProfileTablosu Veri Güncelleme:

        [HttpGet]
        public ActionResult UpdateProfile(int id)
        {
            var values = context.Profile.Find(id);
            return View(values);
        }

        [HttpPost]
        public ActionResult UpdateProfile(Profile profile)
        {
            var values = context.Profile.Find(profile.profileid);
            values.Title = profile.Title;
            values.Description=profile.Description;
            values.Adres= profile.Adres;
            values.Email= profile.Email;
            values.PhoneNumber= profile.PhoneNumber;
            values.Github= profile.Github;
            values.İmageUrl = profile.İmageUrl;
            values.MapLocation = profile.MapLocation;
            context.SaveChanges();
            return RedirectToAction("ProfileList");
        }
        //----------------------------------------------------------------------------------------------------
    }
}