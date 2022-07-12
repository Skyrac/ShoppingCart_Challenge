using ShoppingCart_Challenge.Entities.Discounts;

namespace ShoppingCart_Challenge.Entities
{
    public class Warehouse
    {
        private static readonly List<Product> INVENTORY = new List<Product>()
        {
            new Product("A0001", 12.99f),
            new Product("A0002", 3.99f),
        };

        public static void AddDiscount(string productId, IDiscount discount)
        {
            var product = GetProduct(productId);
            if(product != null)
            {
                product.AddDiscount(discount);
            }
        }

        public static void RemoveDiscount(string productId)
        {
            var product = GetProduct(productId);
            if (product != null)
            {
                product.AddDiscount(null);
            }
        }

        public static Product? GetProduct(string productId)
        {
            return INVENTORY.FirstOrDefault(product => product.Id.Equals(productId));
        }
    }
}
