using ShoppingCart_Challenge.Entities;
using ShoppingCart_Challenge.Entities.Discounts;

namespace Test_ShoppingCart
{
    public class UnitTest1
    {
        [Fact]
        public void AddValidProductShouldReturnTotalPriceForThisProduct()
        {
            var cart = new Cart();

            var total = cart.Scan("A0001");

            var expected = 12.99f;

            Assert.Equal(expected, total);
        }

        [Fact]
        public void ShouldHaveQuantityTwoIfSameProductIsScannedTwice()
        {
            var cart = new Cart();

            var total = cart.Scan("A0001");
            total = cart.Scan("A0001");

            var quantity = cart.GetExistingItem("A0001").Quantity;

            var expected = 2;

            Assert.Equal(expected, quantity);
        }

        [Fact]
        public void AddTwoDifferentValidProductsShouldReturnTotalPriceForThisProducts()
        {
            var cart = new Cart();

            var total = cart.Scan("A0001");
            total = cart.Scan("A0002");

            var expected = Warehouse.GetProduct("A0001")?.Price + Warehouse.GetProduct("A0002")?.Price;

            Assert.Equal(expected, total);
        }

        [Fact]
        public void ShouldGetOneFreeIfGetFreeDiscountIsPlaced()
        {
            var cart = new Cart();
            var discounts = new Dictionary<int, int>() { { 1, 1 } };
            Warehouse.GetProduct("A0002")!.AddDiscount(new GetFreeDiscount(discounts));


            var total = cart.Scan("A0002");
            total = cart.Scan("A0002");

            var expected = Warehouse.GetProduct("A0002")?.Price;

            Assert.Equal(expected, total);
        }

        [Fact]
        public void ShouldGetPercentageOffCertainProduct()
        {
            var cart = new Cart();
            var discounts = new Dictionary<int, double>() { { 0, 10 } };
            Warehouse.GetProduct("A0001")!.AddDiscount(new PercentageDiscount(discounts));


            var total = cart.Scan("A0001");

            var expected = Math.Round(Warehouse.GetProduct("A0001")!.Price * 0.9, 2);

            Assert.Equal((double)expected, total);
        }

        [Fact]
        public void ShouldGetPercentageOffCertainProductWhenMixedWithOthers()
        {
            var cart = new Cart();
            var discounts = new Dictionary<int, double>() { { 0, 10 } };
            Warehouse.GetProduct("A0001")!.AddDiscount(new PercentageDiscount(discounts));


            var total = cart.Scan("A0002");
            total = cart.Scan("A0001");
            total = cart.Scan("A0002");

            var expected = Math.Round(Warehouse.GetProduct("A0001")!.Price * 0.9 + Warehouse.GetProduct("A0002")!.Price * 2, 2) ;

            Assert.Equal(expected, total);
        }
    }
}