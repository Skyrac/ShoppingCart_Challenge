namespace ShoppingCart_Challenge.Entities.Discounts
{
    public class PercentageDiscount : IDiscount
    {
        public Dictionary<int, double> discounts = new Dictionary<int, double>();

        public PercentageDiscount(Dictionary<int, double> discounts)
        {
            this.discounts = discounts;
        }   

        public double CalculateDiscountedCost(double pricePerProduct, int quantity)
        {
            var discountedQuantity = discounts.Any(entry => entry.Key < quantity)
                ? discounts.Where(entry => entry.Key < quantity)
                            .Max(item => item.Key) 
                : -1;
            var discountedPrice = discountedQuantity == -1 ? pricePerProduct : pricePerProduct - pricePerProduct * discounts[discountedQuantity] / 100;
            return discountedPrice * quantity;
        }
    }
}
