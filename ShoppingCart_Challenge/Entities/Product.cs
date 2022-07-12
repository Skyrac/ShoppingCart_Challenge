using ShoppingCart_Challenge.Entities.Discounts;

namespace ShoppingCart_Challenge.Entities
{
    public class Product
    {
        public string Id { get; private set; }
        public double Price { get; private set; }
        public IDiscount? Discount { get; private set; }

        public Product(string id, double price, IDiscount? discount = null)
        {
            Id = id;
            Price = price;
            Discount = discount;
        }

        public void AddDiscount(IDiscount? discount)
        {
            Discount = discount;
        }

        public double GetCost(int quantity)
        {
            if (Discount == null)
            {
                return Price * quantity;
            }
            return Discount.CalculateDiscountedCost(Price, quantity);
        }
    }
}
