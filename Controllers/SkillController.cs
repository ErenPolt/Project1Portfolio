using Project1Portfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using Newtonsoft.Json.Linq;

namespace Project1Portfolio.Controllers
{
    public class SkillController : Controller
    {
        myportfolioEntities context = new myportfolioEntities(); 

        public ActionResult SkillList(int P = 1)
        {
            var values = context.Skill.ToList().ToPagedList(P, 5);
            return View(values);
        }
        //--------------------------------------------------------------------
        [HttpGet]
        public ActionResult CreateSkill()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateSkill(Skill skill)
        {
            context.Skill.Add(skill);
            context.SaveChanges();
            return RedirectToAction("SkillList");
        }
        //-----------------------------------------------------------------------------
        public ActionResult DeleteSkill(int id)
        {
            var value = context.Skill.Find(id);
            context.Skill.Remove(value);
            context.SaveChanges();
            return RedirectToAction("SkillList");
        }
        //--------------------------------------------------------

        //Skill Tablosu Güncelleme:
        [HttpGet]
        public ActionResult UpdateSkill(int id)
        {
            var value = context.Skill.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateSkill(Skill skill)
        {
            var value = context.Skill.Find(skill.Skillİd);
            value.Title = skill.Title;
            value.İcon = skill.İcon;
            value.Value = skill.Value;
            context.SaveChanges();
            return RedirectToAction("SkillList");
        }
        //------------------------------------------------------------------------
    }
}