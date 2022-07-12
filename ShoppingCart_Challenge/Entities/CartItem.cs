using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart_Challenge.Entities
{
    public class CartItem
    {
        public Product Product { get; private set; }
        public int Quantity { get; private set; } = 1;

        public CartItem(Product product, int quantity)
        {
            Product = product;
            Quantity = quantity;
        }

        public double Add(int quantity)
        {
            Quantity += quantity;
            return GetCost();
        }

        public double Remove(int quantity)
        {
            Quantity -= quantity;
            return GetCost();
        }

        public double SetQuantity(int quantity)
        {
            Quantity = quantity;
            return GetCost();
        }

        public double GetCost()
        {
            return Product.GetCost(Quantity);
        }
    }
}
