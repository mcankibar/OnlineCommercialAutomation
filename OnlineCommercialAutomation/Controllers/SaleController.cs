using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineCommercialAutomation.Models.Classes;

namespace OnlineCommercialAutomation.Controllers
{

    public class SaleController : Controller
    {
        Context context = new Context();

        // GET: Sale
        public ActionResult Index()
        {
            var sales = context.SalesTransactionS.ToList();

            return View(sales);
        }


        public ActionResult SaleAdd()
        {
            List<SelectListItem> productList = (from x in context.Products.ToList() select new SelectListItem {Text = x.Name ,Value = x.Id.ToString() }).ToList();
            ViewBag.products = productList;


            List<SelectListItem> customerList = (from x in context.Customers.ToList() select new SelectListItem { Text = x.Name +" " +x.Surname, Value = x.Id.ToString() }).ToList();
            ViewBag.customers = customerList;

            List<SelectListItem> personalList = (from x in context.Personals.ToList() select new SelectListItem { Text = x.Name + " " + x.Surname, Value = x.Id.ToString() }).ToList();
            ViewBag.personals = personalList;

            return View();
        }

        [HttpPost]
        public ActionResult SaleAdd(SalesTransaction salesTransaction)
        {
             context.SalesTransactionS.Add(salesTransaction);
            context.SaveChanges();

            return RedirectToAction("Index");
        }


        public ActionResult SaleUpdate(int id)
        {

            var sale = context.SalesTransactionS.Find(id);
            
            List<SelectListItem> productList = (from x in context.Products.ToList() select new SelectListItem { Text = x.Name, Value = x.Id.ToString() }).ToList();
            ViewBag.products = productList;


            List<SelectListItem> customerList = (from x in context.Customers.ToList() select new SelectListItem { Text = x.Name + " " + x.Surname, Value = x.Id.ToString() }).ToList();
            ViewBag.customers = customerList;

            List<SelectListItem> personalList = (from x in context.Personals.ToList() select new SelectListItem { Text = x.Name + " " + x.Surname, Value = x.Id.ToString() }).ToList();
            ViewBag.personals = personalList;

            return View(sale);
        }

        [HttpPost]
        public ActionResult SaleUpdate(SalesTransaction salesTransaction)
        {
            var updatedSale = context.SalesTransactionS.Find(salesTransaction.Id);
            updatedSale.CustomerId = salesTransaction.CustomerId;
            updatedSale.ProductId = salesTransaction.ProductId;
            updatedSale.Amount = salesTransaction.Amount;
            updatedSale.Date = salesTransaction.Date;
            updatedSale.Price = salesTransaction.Price;
            updatedSale.TotalPrice = salesTransaction.TotalPrice;
            context.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult SaleDetail(int id)
        {
            var sale = context.SalesTransactionS.Where(x => x.Id == id).FirstOrDefault();

            return View(sale);
        }


        [HttpGet]
        public JsonResult GetProductPrice(int productId)
        {
            var productPrice = context.Products
                                      .Where(p => p.Id == productId)
                                      .Select(p => p.SalePrice)
                                      .FirstOrDefault();
            return Json(productPrice, JsonRequestBehavior.AllowGet);
        }

    }
}