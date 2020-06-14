using ShoppingCart.UnitTests.Models;

namespace ShoppingCart.UnitTests.Domain.ShoppingCartManagement.Calculators
{
    public class CouponRateDiscountCalculator : ICouponDiscountCalculator
    {
        public double Calculate(Coupon coupon, double price)
        {
            return price - price * coupon.Discount / 100;
        }
    }
}
