using ShoppingCart.Domain.Models;

namespace ShoppingCart.Domain.ShoppingCartManagement.Calculators
{
    public class CouponRateDiscountCalculator : ICouponDiscountCalculator
    {
        public double Calculate(Coupon coupon, double price)
        {
            return price - price * coupon.Discount / 100;
        }
    }
}
