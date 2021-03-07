using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ch24ShoppingCartMVC.Models
{
    public class CheckoutViewModel
    {
        public string PaymentMethod { get; set; }
        public string ShippingAddress { get; set; }
    }
}