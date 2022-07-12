namespace ShoppingCart_Challenge.Entities
{
    public class Cart
    {
        public List<CartItem> Items { get; private set; } = new List<CartItem>();
        public double Total { get; private set; }

        public double Scan(string productId)
        {
            var product = Warehouse.GetProduct(productId);
            if(product == null) { throw new KeyNotFoundException("Product not in inventory"); }
            return AddItem(new CartItem(product, 1));
        }

        public double SetQuantity(string productId, int quantity)
        {
            var product = Warehouse.GetProduct(productId);
            if (product == null) { throw new KeyNotFoundException("Product not in inventory"); }
            return AddItemAndSetQuantity(new CartItem(product, quantity));
        }

        private double AddItem(CartItem item)
        {
            var existingItem = GetExistingItem(item.Product.Id);
            if (existingItem == null)
            {
                Items.Add(item);
            } else
            {
                existingItem.Add(item.Quantity);
            }
            return CalculateTotal();
        }

        private double AddItemAndSetQuantity(CartItem item)
        {
            var existingItem = GetExistingItem(item.Product.Id);
            if (existingItem == null)
            {
                Items.Add(item);
            }
            else
            {
                if (item.Quantity <= 0)
                {
                    Items.Remove(existingItem);
                }
                else
                {
                    existingItem.SetQuantity(item.Quantity);
                }
            }
            return CalculateTotal();
        }

        private double RemoveItem(CartItem item)
        {
            var existingItem = GetExistingItem(item.Product.Id);
            if(existingItem != null)
            {
                if(existingItem.Quantity  - item.Quantity >= 1)
                {
                    existingItem.Remove(item.Quantity);
                } else
                {
                    Items.Remove(existingItem);
                }
            }
            return CalculateTotal();
        }

        private double CalculateTotal()
        {
            Total = Math.Round(Items.Select(item => item.GetCost()).Sum(), 2);
            return Total;
        }

        public CartItem? GetExistingItem(string productId)
        {
            return Items.FirstOrDefault(item => item.Product.Id.Equals(productId));
        }
    }
}
