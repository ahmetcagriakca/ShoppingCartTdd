using ShoppingCart.Domain.Models;

namespace ShoppingCart.Domain.ShoppingCartManagement.Calculators
{
    public class CouponAmountDiscountCalculator : ICouponDiscountCalculator
    {
        public double Calculate(Coupon coupon, double price)
        {
            return price - coupon.Discount;
        }
    }
}
