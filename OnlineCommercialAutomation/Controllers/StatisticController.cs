using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineCommercialAutomation.Models.Classes;

namespace OnlineCommercialAutomation.Controllers
{
    public class StatisticController : Controller
    {
        Context context = new Context();    
        public ActionResult Index()
        {

            ViewBag.d1 = context.Customers.Count();
            ViewBag.d2 = context.Products.Count();
            ViewBag.d3 = context.Personals.Count();
            ViewBag.d4 = context.Categories.Count();
            ViewBag.d5 = context.Products.Sum(i => i.Stock);
            ViewBag.d6 = context.Products.Select(i => i.Manufacturer).Distinct().Count();
            ViewBag.d7 = context.Products.Count(i => i.Stock < 10);

            //var maxPrice = context.Products.Max(i => i.SalePrice);
            //ViewBag.d8 = context.Products.Where(i => i.SalePrice == maxPrice).Select(p =>p.Name).FirstOrDefault().ToString();

           
            ViewBag.d8 = context.Products.OrderByDescending(i => i.SalePrice).Select(k=>k.Name).FirstOrDefault().ToString();


            //var minPrice = context.Products.Min(i => i.SalePrice);
            //ViewBag.d9 = context.Products.Where(i => i.SalePrice == minPrice).Select(p => p.Name).FirstOrDefault().ToString();

            ViewBag.d9 = context.Products.OrderBy(i => i.SalePrice).Select(k => k.Name).FirstOrDefault().ToString();

            ViewBag.d10 = context.Products.Where(i => i.Name == "Fridge").Sum(k => k.Stock).ToString();

            ViewBag.d11 = context.Products.Where(i => i.Name == "IPhone").Sum(k => k.Stock).ToString();

            ViewBag.d12 = context.Products.GroupBy(i => i.Manufacturer).OrderByDescending(k=>k.Count()).Select(y => y.Key).FirstOrDefault();

            var mostSaledProductId = context.SalesTransactionS.GroupBy(i => i.ProductId).OrderByDescending(k => k.Sum(p => p.Amount)).Select(y => y.Key).FirstOrDefault();
            ViewBag.d13 = context.Products.Where(i=>i.Id == mostSaledProductId).Select(k=>k.Name).FirstOrDefault();

            ViewBag.d14 = context.SalesTransactionS.Sum(x=>x.TotalPrice);

            ViewBag.d15 = context.SalesTransactionS.Count(x => x.Date == DateTime.Today);


            ViewBag.d16 = context.SalesTransactionS.Where(x => x.Date == DateTime.Today).Select(i => (decimal?)i.TotalPrice)
                     .Sum() ?? 0;



            return View();
        }


        public ActionResult SimpleTables()
        {

            var query = from x in context.Customers
                        group x by x.City into g
                        select new SimpleTableGroup
                        {
                            City = g.Key,
                            Total = g.Count()
                        };

            return View(query.ToList());
        }

        public PartialViewResult FirstPartial()
        {

            var personalCount = from x in context.Personals
                                group x by x.Department.Name into g
                                select new PersonalGroup
                                {
                                    Department = g.Key,
                                    Amount = g.Count()
                                };
            return PartialView(personalCount.ToList());
        }


        public PartialViewResult SecondPartial()
        {

            var customers = context.Customers.ToList();
            return PartialView(customers);
        }

        public PartialViewResult ThirdPartial()
        {

            var products = context.Products.ToList();
            return PartialView(products);
        }


        public PartialViewResult FourthPartial()
        {
            var manufacturerQuery = from x in context.Products
                                group x by x.Manufacturer into g
                                select new ManufacturerGroup
                                {
                                    manufacturer = g.Key,
                                    count = g.Count()
                                };
            return PartialView(manufacturerQuery.ToList());
        }


        public PartialViewResult FifthPartial()
        {
            var categoryGroupQuery = from x in context.Products
                                    group x by x.Category.Name into g
                                    select new CategoryGroup
                                    {
                                        Category = g.Key,
                                        Count = g.Count()
                                    };
            return PartialView(categoryGroupQuery.ToList());
        }
    }


}