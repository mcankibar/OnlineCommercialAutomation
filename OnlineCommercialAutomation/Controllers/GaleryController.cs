using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineCommercialAutomation.Models.Classes;

namespace OnlineCommercialAutomation.Controllers
{
    
    public class GaleryController : Controller
    {
        Context context = new Context();
        // GET: Galery
        public ActionResult Index()
        {
            var values = context.Products.ToList();

            return View(values);
        }
    }
}