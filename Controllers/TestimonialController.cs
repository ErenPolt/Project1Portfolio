using Project1Portfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project1Portfolio.Controllers
{
    public class TestimonialController : Controller
    {
        myportfolioEntities context = new myportfolioEntities();
        public ActionResult TestimonialList()//Testimonial Tablosu Listeleme
        {
            var values = context.Testimonial.ToList();
            return View(values);
        }
        //-----------------------------------------------------------------------------------------------
        //Testimonial tablosu Veri Silme:
        public ActionResult DeleteTestimonial(int id)
        {
            var values = context.Testimonial.Find(id);
            context.Testimonial.Remove(values);
            context.SaveChanges();
            return RedirectToAction("TestimonialList");
        }
        //------------------------------------------------------------------------
        //Testimonial Tablosu Veri Ekleme:
        [HttpGet]
        public ActionResult CreateTestimonial()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateTestimonial(Testimonial testimonial)
        {
            context.Testimonial.Add(testimonial);
            context.SaveChanges();
            return RedirectToAction("TestimonialList");
        }
        //-------------------------------------------------------------------------------------
        //Testimonial Tablosu Veri Güncelleme
        [HttpGet]
        public ActionResult UpdateTestimonial(int id)
        {
            var values = context.Testimonial.Find(id);
            return View(values);
        }

        [HttpPost]
        public ActionResult UpdateTestimonial(Testimonial testimonial)
        {
            var values = context.Testimonial.Find(testimonial.Testimonialid);
            values.Title = testimonial.Title;
            values.Name = testimonial.Name;
            values.Comment = testimonial.Comment;
            values.İmageUrl = testimonial.İmageUrl;
            context.SaveChanges();
            return RedirectToAction("TestimonialList");
        }
        //-----------------------------------------------------------------------------------
    }
}