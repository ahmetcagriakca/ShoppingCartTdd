using ShoppingCart.UnitTests.Models.Enums;

namespace ShoppingCart.UnitTests.Models
{
    public class Coupon
    {
        public double MinimumCartAmount { get; }
        public int DiscountPercentage { get; }
        public DiscountType DiscountType { get; }

        public Coupon(in double minimumCartAmount, in int discountPercentage, DiscountType discountType)
        {
            MinimumCartAmount = minimumCartAmount;
            DiscountPercentage = discountPercentage;
            DiscountType = discountType;
        }
    }
}