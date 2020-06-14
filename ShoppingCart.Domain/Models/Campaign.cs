using ShoppingCart.Domain.Models.Enums;
using ShoppingCart.Domain.ShoppingCartManagement.Calculators;

namespace ShoppingCart.Domain.Models
{
    public class Campaign
    {
        public Category Category { get; }
        public double Discount { get; }
        public int MinimumItemCount { get; }
        public DiscountType DiscountType { get; }
        public ICampaignDiscountCalculator DiscountCalculator { get; }


        public Campaign(Category category, in double discount, in int minimumItemCount, DiscountType discountType)
        {
            Category = category;
            Discount = discount;
            MinimumItemCount = minimumItemCount;
            DiscountType = discountType;
            DiscountCalculator = discountType switch
            {
                DiscountType.Rate => new CampaignRateDiscountCalculator(),
                DiscountType.Amount => new CampaignAmountDiscountCalculator(),
                _ => DiscountCalculator
            };
        }

        public double CalculateDiscountForProduct(ShoppingCartProduct product)
        {
            return DiscountCalculator.Calculate(this, product);
        }
    }
}