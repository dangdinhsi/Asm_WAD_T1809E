using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestAsm.Models
{
    public class MyCart
    {
        public Dictionary<int, CartItem> Items { get; set; }
        private double TotalPrice = 0;
        public double getTotalPrice()
        {
            this.TotalPrice = 0;
            foreach (var item in Items.Values)
            {
                this.TotalPrice += item.Product.Price * item.Quantity;
            }
            return this.TotalPrice;
        }
        public MyCart()
        {
            Items = new Dictionary<int, CartItem>();
        }
        public void addCart(Product product, int quantity)
        {
            if (Items.ContainsKey(product.Id))
            {
                //item luc nay = item trong dictionary voi key = productId
                var item = Items[product.Id];
                //Da ton tai item nen chi can cap nhat lai quantity cua item.
                item.Quantity += quantity;
                //Gan lai item tai key = productId bang item moi cap nhat
                Items[product.Id] = item;
                return;
            }
            var cart = new CartItem(product, quantity);
            Items.Add(product.Id, cart);
        }

        public void updateCart(Product product, int quantity)
        {
            if (Items.ContainsKey(product.Id))
            {
                var item = Items[product.Id];
                item.Quantity = quantity;
                Items[product.Id] = item;
            }
        }
        public void removeCart(Product product)
        {
            Items.Remove(product.Id);
        }
    }
}