using Project1Portfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project1Portfolio.Controllers
{
    public class GraficController : Controller
    {
        myportfolioEntities context = new myportfolioEntities();
        public PartialViewResult PartialChartSkill()
        {
            var values = context.Skill.ToList();
            return PartialView("PartialChartSkill", values);
        }
    }
}