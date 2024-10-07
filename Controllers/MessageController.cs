using Project1Portfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project1Portfolio.Controllers
{
    public class MessageController : Controller
    {
        myportfolioEntities context = new myportfolioEntities();//context nesnesi

        public ActionResult Inbox()//mesaj listeleme
        {
            var values = context.Message.ToList();
            return View(values);
        }
        public ActionResult MessageDetails(int id)//Mesaj Detayları
        {
            var value = context.Message.Where(x => x.Mesaageid == id).FirstOrDefault();
            return View(value);

        }
        public ActionResult MessageStatusChangeToTrue(int id)
        {
            var value = context.Message.Where(x => x.Mesaageid == id).FirstOrDefault();
            value.İsRead = true;
            context.SaveChanges();
            return RedirectToAction("Inbox");
        }

        public ActionResult MessageStatusChangeToFalse(int id)
        {
            var value = context.Message.Where(x => x.Mesaageid == id).FirstOrDefault();
            value.İsRead = false;
            context.SaveChanges();
            return RedirectToAction("Inbox");
        }
    }
}