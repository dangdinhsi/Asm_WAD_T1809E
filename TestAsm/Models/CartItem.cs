using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TestAsm.Models
{
    public class CartItem
    {
        public Product Product { get; set; }

        [Range(0,100,ErrorMessage = "Không thể âm")]
        public int Quantity { get; set; }
        public CartItem(Product product, int quantity)
        {
            Product = product;
            Quantity = quantity;
        }
        public CartItem()
        {
        }
    }
}