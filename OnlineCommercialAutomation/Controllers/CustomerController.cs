using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineCommercialAutomation.Models.Classes;

namespace OnlineCommercialAutomation.Controllers
{
    public class CustomerController : Controller
    {
        Context context = new Context();
        public ActionResult Index()
        {
            var customersList = context.Customers.Where(i => i.IsActive == true).ToList();
            return View(customersList);
        }

        public ActionResult CustomerAdd()
        {
            
            return View();
        }

        [HttpPost]
        public ActionResult CustomerAdd(Customer customer)
        {
            context.Customers.Add(customer);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult CustomerRemove(int  id)
        {
            var selectedCustomer = context.Customers.Find(id);
            selectedCustomer.IsActive = false;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult CustomerUpdate(int id)
        {
            var customer = context.Customers.Find(id);

            return View(customer);
        }

        [HttpPost]
        public ActionResult CustomerUpdate(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return View("CustomerUpdate");
            }
            var updateCustomer = context.Customers.Find(customer.Id);
             updateCustomer.Name = customer.Name;
             updateCustomer.Surname = customer.Surname;
             updateCustomer.City = customer.City;
             updateCustomer.Mail = customer.Mail;
            context.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult CustomerSales(int id)
        {
           var salesList = context.SalesTransactionS.Where(i => i.CustomerId==id).ToList();
            
            return View(salesList);
        }



    }
}