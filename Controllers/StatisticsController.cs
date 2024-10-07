using Project1Portfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project1Portfolio.Controllers
{
    public class StatisticsController : Controller
    {
        myportfolioEntities context = new myportfolioEntities();//context nesnesi
        public ActionResult Index()
        {
            int messageCount = context.Message.Count();
            int messageCountIsReadyTrue = context.Message.Where(x => x.İsRead == true).Count();
            int messageCountIsReadyFalse= context.Message.Where(x => x.İsRead == false).Count();
            int skillCount = context.Skill.Count();
            var totalskillValue = context.Skill.Sum(x=>x.Value);
            var averageSkillValue = context.Skill.Average(x => x.Value);
            var getEmailFromProfile = context.Profile.Select(x => x.Email).FirstOrDefault();
            var getLastCategoryid = context.Category.Max(x => x.Categoryid);
            var getLastCategoryName = context.Category.Where(x=>x.Categoryid==getLastCategoryid).Select(y=>y.CategoryName).FirstOrDefault();

            ViewBag.messageCount = messageCount;
            ViewBag.messageCountIsReadyTrue = messageCountIsReadyTrue;
            ViewBag.messageCountIsReadyFalse = messageCountIsReadyFalse;
            ViewBag.skillCount = skillCount;
            ViewBag.totalskillValue = totalskillValue;
            ViewBag.averageSkillValue = averageSkillValue;
            ViewBag.getEmailFromProfile = getEmailFromProfile;
            ViewBag.getLastCategoryName = getLastCategoryName;  
            return View();
        }
    }
}