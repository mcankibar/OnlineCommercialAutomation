using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineCommercialAutomation.Models.Classes;

namespace OnlineCommercialAutomation.Controllers
{
    public class InvoiceController : Controller
    {

        Context context = new Context();
        public ActionResult Index()
        {
            var invoicesList = context.Invoices.ToList();

            return View(invoicesList);
        }


        public ActionResult InvoiceAdd()
        {
           

            return View();
        }

        [HttpPost]
        public ActionResult InvoiceAdd(Invoice invoice)
        {
            context.Invoices.Add(invoice);
            context.SaveChanges();

            return RedirectToAction("Index");
        }


        public ActionResult InvoiceUpdate(int id)
        {
            var invoice = context.Invoices.Find(id);

            return View(invoice);
        }

        [HttpPost]
        public ActionResult InvoiceUpdate(Invoice invoice)
        {
            var updatableInvoice = context.Invoices.Find(invoice.Id);
            updatableInvoice.SerialNumber = invoice.SerialNumber;
            updatableInvoice.OrderNumber = invoice.OrderNumber;
            updatableInvoice.ReceivedBy = invoice.ReceivedBy;
            updatableInvoice.DeliveredBy = invoice.DeliveredBy;
            updatableInvoice.Date = invoice.Date;
            updatableInvoice.TaxOffice = invoice.TaxOffice;
            updatableInvoice.Time = invoice.Time;
            context.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult InvoiceDetail(int id)
        {
            var invoiceItems = context.InvoiceItems.Where(i => i.InvoiceId==id).ToList();

            return View(invoiceItems);
        }

        public ActionResult InvoiceAddDetail(int id)
        {
            ViewBag.InvoiceId = id;

            return View();
        }

        [HttpPost]
        public ActionResult InvoiceAddDetail(InvoiceItem invoiceItem)
        {
            invoiceItem.InvoiceId = invoiceItem.InvoiceId;

            context.InvoiceItems.Add(invoiceItem);
            context.SaveChanges();

            return RedirectToAction("InvoiceDetail", new { id = invoiceItem.InvoiceId });
        }

    }
}