using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineCommercialAutomation.Models.Classes;

namespace OnlineCommercialAutomation.Controllers
{
    public class CategoryController : Controller
    {

        Context context = new Context();
        public ActionResult Index()
        {

            var values = context.Categories.ToList();
            return View(values);
        }

        public ActionResult CategoryAdd() { 
            return View();
        }

        [HttpPost]
        public ActionResult CategoryAdd(Category category)
        {
            context.Categories.Add(category);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult CategoryRemove(int id)
        {

            Category category = context.Categories.Find(id);
            context.Categories.Remove(category);
            context.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult CategoryUpdate(int id )
        {
            Category category = context.Categories.Find(id);

           
            return View(category);
        }
        [HttpPost]
        public ActionResult CategoryUpdate(Category category)
        {
            var updateCategory = context.Categories.Find(category.Id);
            updateCategory.Id = category.Id;
            updateCategory.Name = category.Name;
            context.SaveChanges();



            return RedirectToAction("Index");
        }


    }
}