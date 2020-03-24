using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestAsm.Data;
using TestAsm.Models;

namespace TestAsm.Controllers
{
    public class ShoppingCartController : ClientController
    {
        private TestAsmContext db = new TestAsmContext();
        // GET: ShoppingCart
        public ActionResult Showcart()
        {
            var cart = (MyCart)Session["cart"];
            if (Session["cart"] == null)
            {
                cart = new MyCart();
            }
            return View(cart);
        }
        public ActionResult AddToCart(int productId, int quantity)
        {
            var cart = (MyCart)Session["cart"];
            var product = db.Products.FirstOrDefault(x => x.Id == productId);
            if (product == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            if (Session["cart"] == null)
            {
                cart = new MyCart();
            }
            cart.addCart(product, quantity);
            saveCart(cart);
            SetAlert("Thêm thành công sản phẩm vào giỏ hàng", "success");
            return Redirect("/Client/Index");
        }
        public ActionResult RemoveCart(int productId)
        {
            var cart = (MyCart)Session["cart"];
            var product = db.Products.FirstOrDefault(x => x.Id == productId);
            if (product == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            if (Session["cart"] == null)
            {
                cart = new MyCart();
            }
            cart.removeCart(product);
            saveCart(cart);
            SetAlert("Xóa sản phẩm thành công", "success");
            return RedirectToAction("Showcart");
        }
        public ActionResult RemoveCart2(int productId)
        {
            var cart = (MyCart)Session["cart"];
            var product = db.Products.FirstOrDefault(x => x.Id == productId);
            if (product == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            if (Session["cart"] == null)
            {
                cart = new MyCart();
            }
            cart.removeCart(product);
            saveCart(cart);
            //SetAlert("Xóa sản phẩm thành công", "success");
            return Redirect("/Client/Index");
        }

        [HttpPost]
        public ActionResult UpdateCart(FormCollection collection)
        {
            
                var cart = (MyCart)Session["cart"];
                string[] ids = collection.GetValues("productId");
                string[] quantities = collection.GetValues("quantity");
                for (var i = 0; i < ids.Length; i++)
                {
                    var id = Convert.ToInt32(ids[i]);
                    var existProduct = db.Products.FirstOrDefault(x => x.Id == id);
                    if (existProduct == null)
                    {
                        return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
                    }
                if (Convert.ToInt32(quantities[i]) < 0)
                {
                    SetAlert("Số lượng cập nhật không thể âm", "error");
                    return View("Showcart", cart);
                }
                if (Session["cart"] == null)
                    {
                        cart = new MyCart();
                    }
                    if (Convert.ToInt32(quantities[i]) == 0)
                    {
                        cart.removeCart(existProduct);
                    }
                    cart.updateCart(existProduct, Convert.ToInt32(quantities[i]));
                    saveCart(cart);
                }
                SetAlert("Cập nhật sản phẩm trong giỏ hàng thành công", "success");
            return RedirectToAction("Showcart");
        }
        public ActionResult RemoveAll()
        {
            Session.Remove("cart");
            SetAlert("Xóa thành công", "success");
            return RedirectToAction("Showcart");
        }
        private void saveCart(MyCart cart)
        {
            Session["cart"] = cart;
        }
    }
}