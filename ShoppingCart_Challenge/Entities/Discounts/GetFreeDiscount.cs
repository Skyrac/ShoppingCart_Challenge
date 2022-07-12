namespace ShoppingCart_Challenge.Entities.Discounts
{
    public class GetFreeDiscount : IDiscount
    {
        public Dictionary<int, int> discounts = new Dictionary<int, int>();

        public GetFreeDiscount(Dictionary<int, int> discounts)
        {
            this.discounts = discounts;
        }

        public double CalculateDiscountedCost(double pricePerProduct, int quantity)
        {
            
            var discountedAmount = discounts.Any(entry => entry.Key < quantity) 
                ? discounts.Where(entry => entry.Key < quantity)
                            .Max(item => item.Key) 
                : -1;
            var freeAmount = discountedAmount == -1 ? quantity : quantity - discounts![discountedAmount];
            return (quantity - freeAmount) * pricePerProduct;
        }
    }
}
