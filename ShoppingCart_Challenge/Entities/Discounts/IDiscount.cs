namespace ShoppingCart_Challenge.Entities.Discounts
{
    public interface IDiscount
    {
        double CalculateDiscountedCost(double pricePerProduct, int amount);
    }
}
