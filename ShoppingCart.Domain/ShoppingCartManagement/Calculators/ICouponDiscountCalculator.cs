using ShoppingCart.Domain.Models;

namespace ShoppingCart.Domain.ShoppingCartManagement.Calculators
{
    public interface ICouponDiscountCalculator
    {
        double Calculate(Coupon coupon, double price);
    }
}
