using ShoppingCart.UnitTests.Domain.ShoppingCartManagement.Calculators;
using ShoppingCart.UnitTests.Models.Enums;

namespace ShoppingCart.UnitTests.Models
{
    public class Coupon
    {
        public double MinimumCartAmount { get; }
        public int Discount { get; }
        public DiscountType DiscountType { get; }
        public ICouponDiscountCalculator DiscountCalculator { get; }

        public Coupon(in double minimumCartAmount, in int discount, DiscountType discountType)
        {
            MinimumCartAmount = minimumCartAmount;
            Discount = discount;
            DiscountType = discountType;
            DiscountCalculator = discountType switch
            {
                DiscountType.Rate => new CouponRateDiscountCalculator(),
                DiscountType.Amount => new CouponAmountDiscountCalculator(),
                _ => DiscountCalculator
            };
        }

        /// <summary>
        /// Total price checked
        /// if price bigger than minimum cart amount calculate discount on price
        /// </summary>
        /// <param name="price"></param>
        /// <returns></returns>
        public double CalculateDiscountForCart(double price)
        {
            if (price < MinimumCartAmount) return price;
            return DiscountCalculator.Calculate(this, price);
        }
    }
}