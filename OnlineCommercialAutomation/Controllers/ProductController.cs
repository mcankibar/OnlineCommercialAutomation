﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineCommercialAutomation.Models.Classes;

namespace OnlineCommercialAutomation.Controllers
{
    public class ProductController : Controller
    {
        Context context = new Context();
        public ActionResult Index()
        {
            var products = context.Products.Where(x=>x.IsActive==true).ToList();


            return View(products);
        }

        public ActionResult ProductAdd()
        {
            List<SelectListItem> categoryDropDownList = (from x in context.Categories.ToList() 
                                                         select new SelectListItem {Text = x.Name , Value = x.Id.ToString() }).ToList();

            ViewBag.categoryValues = categoryDropDownList;

            return View(); 
        }

        [HttpPost]

        public ActionResult ProductAdd(Product product)
        {
            context.Products.Add(product);
            context.SaveChanges();


            return RedirectToAction("Index");
        }


        public ActionResult ProductDelete(int Id)
        {
            var removedProduct = context.Products.Find(Id);
            removedProduct.IsActive = false;

            context.SaveChanges();


            return RedirectToAction("Index");
        }


        public ActionResult ProductUpdate(int id)
        {
            Product product = context.Products.Find(id);
            List<SelectListItem> categoriDropDownList = (from x in context.Categories.ToList()
                                                         select new SelectListItem { Text = x.Name, Value = x.Id.ToString() }).ToList();

            ViewBag.categoryValues = categoriDropDownList;

            return View(product);

        }
        [HttpPost]
        public ActionResult ProductUpdate(Product product)
        {
            var updateProduct = context.Products.Find(product.Id);
            updateProduct.Id = product.Id;
            updateProduct.Name = product.Name;
            updateProduct.PurchasePrice = product.PurchasePrice;
            updateProduct.SalePrice = product.SalePrice;
            updateProduct.ProductImageUrl = product.ProductImageUrl;
            updateProduct.Manufacturer = product.Manufacturer;
            updateProduct.CategoryId = product.CategoryId;
            context.SaveChanges();



            return RedirectToAction("Index");
        }

    }
}