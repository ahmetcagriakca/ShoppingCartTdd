using ShoppingCart.UnitTests.Models;

namespace ShoppingCart.UnitTests.Domain.ShoppingCartManagement.Calculators
{
    public class CouponAmountDiscountCalculator : ICouponDiscountCalculator
    {
        public double Calculate(Coupon coupon, double price)
        {
            return price - coupon.Discount;
        }
    }
}
