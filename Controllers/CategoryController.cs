using Project1Portfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project1Portfolio.Controllers
{
    public class CategoryController : Controller
    {
        myportfolioEntities context = new myportfolioEntities();
        public ActionResult CategoryList()//Kategori Listesi Metodu
        {
            var values = context.Category.ToList();
            return View(values);
        }
        //-----------------------------------------------------
        //Kategori Tablosu Veri Ekleme:

        [HttpGet]
        public ActionResult CreateCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateCategory(Category category)
        {
            context.Category.Add(category);
            context.SaveChanges();
            return RedirectToAction("CategoryList");
        }
        //------------------------------------------------------------------
        //Kategori Tablosu Veri Silme:
        public ActionResult DeleteCategory(int id)
        {
            var value = context.Category.Find(id);
            context.Category.Remove(value);
            context.SaveChanges();
            return RedirectToAction("CategoryList");
        }
        //------------------------------------------------------------
        //Kategori Tablosu Güncelleme:
        [HttpGet]
        public ActionResult UpdateCategory(int id)
        {
            var value = context.Category.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateCategory(Category category)
        {
            var value = context.Category.Find(category.Categoryid);
            value.CategoryName = category.CategoryName;
            value.CategoryStatus = category.CategoryStatus;
            context.SaveChanges();
            return RedirectToAction("CategoryList");
        }
    }
}