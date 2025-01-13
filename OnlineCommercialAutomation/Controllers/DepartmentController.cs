using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineCommercialAutomation.Models.Classes;

namespace OnlineCommercialAutomation.Controllers
{
    public class DepartmentController : Controller
    {

        Context context = new Context();
        // GET: Deparment
        public ActionResult Index()
        {
            var departments = context.Departments.Where(x => x.isActive==true).ToList();
            return View(departments);
        }

        [HttpGet]
        public ActionResult DepartmentAdd()
        {
           
            return View();
        }
        [HttpPost]
        public ActionResult DepartmentAdd(Department department)
        {
            context.Departments.Add(department);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DepartmentUpdate(int id)
        {
            var dep = context.Departments.Find(id);


            
            return View(dep);
        }
        [HttpPost]
        public ActionResult DepartmentUpdate(Department dep)
        {
            var updateDep = context.Departments.Find(dep.Id);
            updateDep.Name = dep.Name;
            
            

            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DepartmentRemove(int id)
        {
            var dep = context.Departments.Find(id);
            if (dep != null) {
                dep.isActive = false;
            }
            
            context.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult DepartmentDetail(int id)
        {

            var personals = context.Personals.Where(p => p.DepartmentId == id).ToList();
            var departmentName = context.Departments.Where(p => p.Id == id ).Select(p => p.Name).FirstOrDefault();
            ViewBag.DepartmentName = departmentName;
            return View(personals);
        }

        public ActionResult DepartmentPersonalSales(int id)
        {

            var personalSales = context.SalesTransactionS.Where(p => p.PersonalId == id).ToList();
           ViewBag.PersonalName = context.Personals.Where(p=>p.Id==id).Select(i => i.Name + " "+ i.Surname).FirstOrDefault();
            return View(personalSales);
        }
    }
}