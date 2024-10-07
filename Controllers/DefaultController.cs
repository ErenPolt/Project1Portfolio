using Project1Portfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project1Portfolio.Controllers
{

    public class DefaultController : Controller
    {
        myportfolioEntities context = new myportfolioEntities();    
        public ActionResult Index()
        {
            List<SelectListItem> values = (from x in context.Category.ToList()
                                           select new SelectListItem
                                           {
                                               Text=x.CategoryName,
                                               Value=x.Categoryid.ToString()
                                           }).ToList();
            ViewBag.V = values;
            return View();
        }

        [HttpPost]
        public ActionResult Index(Message message)
        {
            message.SendDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            message.İsRead = false;
            context.Message.Add(message);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public PartialViewResult PartialHead()//Yol kısmı
        {
            return PartialView();
        }
        public PartialViewResult PartialNavbar()//Navbar Kısmı
        {
            return PartialView();
        }
        public PartialViewResult PartialHeader()
        {//About Tablosu
            ViewBag.title = context.About.Select(x => x.Title).FirstOrDefault();
            ViewBag.detail = context.About.Select(x => x.Detail).FirstOrDefault();
            ViewBag.imageUrl = context.About.Select(x => x.İmageUrl).FirstOrDefault();

            //Profile Tablosu
            ViewBag.address = context.Profile.Select(x => x.Adres).FirstOrDefault();
            ViewBag.email = context.Profile.Select(x => x.Email).FirstOrDefault();
            ViewBag.phone = context.Profile.Select(x => x.PhoneNumber).FirstOrDefault();
            ViewBag.github = context.Profile.Select(x => x.Github).FirstOrDefault();
            
            return PartialView();       
        }

        public PartialViewResult PartialAbout()
        {
            ViewBag.title = context.Profile.Select(x => x.Title).FirstOrDefault();
            ViewBag.description = context.Profile.Select(x => x.Description).FirstOrDefault();
            ViewBag.phone = context.Profile.Select(x => x.PhoneNumber).FirstOrDefault();
            ViewBag.email = context.Profile.Select(x => x.Email).FirstOrDefault();
            ViewBag.imageUrl = context.Profile.Select(x => x.İmageUrl).FirstOrDefault();

            return PartialView();
        }
        public PartialViewResult PartialEducation()
        {
            var values = context.Education.ToList();
            return PartialView(values);
        }
        public PartialViewResult PartialScript()
        {
            return PartialView();
        }
        
        public PartialViewResult PartialSkill()
        {
            var values = context.Skill.ToList();
            return PartialView(values);
        }

        public PartialViewResult PartialSocialMedia()
        {
            var values = context.SocialMedia.Where(x=>x.Status == true).ToList();
            return PartialView(values);
        }

        public PartialViewResult PartialExperience()
        {
            var values = context.Experience.ToList();
            return PartialView(values);
        }

        public PartialViewResult PartialServices()
        {
            var values = context.Services.ToList();
            return PartialView(values);
        }

        public PartialViewResult PartialPortfolio()
        {
            var values = context.Work.ToList();
            return PartialView(values);
        }

        public PartialViewResult PartialTestimonial()
        {
            var values = context.Testimonial.ToList();
            return PartialView(values);
        }
    }
}