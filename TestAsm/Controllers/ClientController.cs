using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TestAsm.Data;
using TestAsm.Models;

namespace TestAsm.Controllers
{
    public class ClientController : Controller
    {
        private TestAsmContext db = new TestAsmContext();

        // GET: Client
        public ActionResult Index()
        {
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name");
            var products = db.Products.Include(p => p.Category).Where(x=>x.Status ==Product.ProductStatus.Active);
            return View(products.ToList());
        }
        public ActionResult SearchCategory(int CategoryId)
        {
            ViewBag.CategoryId =new SelectList(db.Categories, "Id", "Name");
            var products = db.Products.Include(p => p.Category).Where(x => x.CategoryId == CategoryId);
            return View("Index", products.ToList());
        }
        public ActionResult SearchName(string txtSearch)
        {
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name");
            var products = db.Products.Include(p => p.Category).Where(x => x.Name.Contains(txtSearch));
            return View("Index",products.ToList());
        }
        // GET: Client/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        protected void SetAlert(string message, string type)
        {
            TempData["AlertMessage"] = message;
            if (type == "success")
            {
                TempData["AlertType"] = "alert-success";
            }
            else if (type == "warning")
            {
                TempData["AlertType"] = "alert-warning";
            }
            else if (type == "error")
            {
                TempData["AlertType"] = "alert-danger";
            }
        }
    }
}
