using ShoppingCart.UnitTests.Models;

namespace ShoppingCart.UnitTests.Domain.ShoppingCartManagement.Calculators
{
    public class CampaignRateDiscountCalculator : ICampaignDiscountCalculator
    {
        public double Calculate(Campaign campaign, ShoppingCartProduct product)
        {
            return product.DiscountedPrice - product.DiscountedPrice * campaign.Discount / 100;
        }
    }
}
