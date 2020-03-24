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
using PagedList.Mvc;
using PagedList;
using System.Diagnostics;

namespace TestAsm.Controllers
{
    public class ClientController : Controller
    {
        private TestAsmContext db = new TestAsmContext();

        // GET: Client
        public ActionResult Index()
        {
            // Khai báo thanh dropdown list ở index, nếu không khai báo,viewbag không có dữ liêu categoryid => lỗi.
            IEnumerable<SelectListItem> selectLists = new SelectList(db.Categories, "Id", "Name");
            ViewBag.CategoryId = selectLists;
            var products = db.Products.Include(p => p.Category)/*.Where(x=>x.Status ==Product.ProductStatus.Active)*/;
            return View(products.ToList());
        }
        //public ActionResult SearchCategory(int CategoryId, int? page)
        //{
        //    ViewBag.CategoryId =new SelectList(db.Categories, "Id", "Name");
        //    var products = db.Products.Include(p => p.Category).Where(x => x.CategoryId ==CategoryId);
        //    return View("Index", products.ToList().ToPagedList(page ?? 1, 1));
        //}
        public ActionResult SearchByName(string txtSearch)
        {
            ViewBag.txtSearch = txtSearch;
            var products = db.Products.Include(p => p.Category);
            //IEnumerable<SelectListItem> selectLists = new SelectList(db.Categories, "Id", "Name");
            //ViewBag.CategoryId = selectLists;
            if (!String.IsNullOrEmpty(txtSearch))
            {
                products = db.Products.Include(p => p.Category).Where(x => x.Name.Contains(txtSearch));
            }
            return PartialView("SearchByName", products.ToList()); // xử dụng 1 view partial với ajax helper.
        }

        [HttpPost]
        public ActionResult SearchByCategory(int? CategoryId)  // để ? để nếu categoryid truyền lên nhận giá trị null sẽ ko xảy ra lỗi xung đột kiểu int.
        {
            if (CategoryId == null)
            {
                Debug.WriteLine("true");
            }
            
            var products = db.Products.Include(p => p.Category);
            IEnumerable<SelectListItem> selectLists = new SelectList(db.Categories, "Id", "Name");
            ViewBag.CategoryId = selectLists;
            if (CategoryId != null)
            {
                products = db.Products.Include(p => p.Category).Where(x => x.CategoryId == CategoryId);
            }
            return View("Index", products.ToList());

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
