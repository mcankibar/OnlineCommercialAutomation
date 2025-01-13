using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineCommercialAutomation.Models.Classes;
namespace OnlineCommercialAutomation.Controllers
{
    public class PersonalController : Controller
    {
        Context context = new Context();
        // GET: Personal
        public ActionResult Index()
        {
            var personals = context.Personals.ToList();

            return View(personals);
        }

        public ActionResult PersonalAdd()
        {
            List<SelectListItem> departments = (from x in context.Departments.ToList()select new SelectListItem { Text = x.Name , Value= x.Id.ToString() }).ToList();
            ViewBag.Departments = departments;  
            return View();
        }
        [HttpPost]
        public ActionResult PersonalAdd(Personal personal)
        {
            context.Personals.Add(personal);
            context.SaveChanges();

            return RedirectToAction("Index");
        }


        public ActionResult PersonalUpdate(int id)
        {
            var selectedPersonal = context.Personals.Find(id);
            List<SelectListItem> departments = (from x in context.Departments.ToList() select new SelectListItem { Text = x.Name, Value = x.Id.ToString() }).ToList();
            ViewBag.Departments = departments;
            return View(selectedPersonal);
        }

        [HttpPost]
        public ActionResult PersonalUpdate(Personal personal)
        {
            var updatedPersonal = context.Personals.Find(personal.Id);
            updatedPersonal.Name = personal.Name;
            updatedPersonal.Surname = personal.Surname;
            updatedPersonal.ImageUrl = personal.ImageUrl;
            updatedPersonal.DepartmentId = personal.DepartmentId;
            context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}