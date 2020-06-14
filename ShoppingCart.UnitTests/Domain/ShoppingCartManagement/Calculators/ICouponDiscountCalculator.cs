using ShoppingCart.UnitTests.Models;

namespace ShoppingCart.UnitTests.Domain.ShoppingCartManagement.Calculators
{
    public interface ICouponDiscountCalculator
    {
        double Calculate(Coupon coupon, double price);
    }
}
