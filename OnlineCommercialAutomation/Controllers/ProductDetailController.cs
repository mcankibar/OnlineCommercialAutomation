using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineCommercialAutomation.Models.Classes;

namespace OnlineCommercialAutomation.Controllers
{
    public class ProductDetailController : Controller
    {
        Context context = new Context();
        // GET: ProductDetail
        public ActionResult Index(int id)
        {
            var product = context.Products
        .FirstOrDefault(p => p.Id == id);



            return View(product);
        }
    }
}