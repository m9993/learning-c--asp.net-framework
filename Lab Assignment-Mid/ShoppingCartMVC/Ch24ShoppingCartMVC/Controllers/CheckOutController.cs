using Ch24ShoppingCartMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ch24ShoppingCartMVC.Controllers
{
    public class CheckOutController : Controller
    {
        //
        // GET: /CheckOut/

        [HttpGet]
        public ActionResult Index()
        {
            var model = new CartModel();
            return View(model.GetCart());
        }


        [HttpPost]
        public ActionResult ConfirmOrder(CheckoutViewModel checkoutViewModel)
        {
            CheckoutViewModel cvm = new CheckoutViewModel();
            cvm.ShippingAddress = checkoutViewModel.ShippingAddress;
            cvm.PaymentMethod = checkoutViewModel.PaymentMethod;
            if (cvm.ShippingAddress==null)
            {
                TempData["msg"]= "Shipping Address Required";
                return RedirectToAction("Index");
            }
            if (cvm.PaymentMethod == null)
            {
                TempData["msg"] = "Payment Method Required";
                return RedirectToAction("Index");
            }
            Session["cart"] = null;
            TempData["cart"] = null;
            return View(cvm);
        }
    }
}
