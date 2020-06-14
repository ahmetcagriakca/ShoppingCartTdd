using ShoppingCart.Domain.Models;

namespace ShoppingCart.Domain.ShoppingCartManagement.Calculators
{
    public class CampaignRateDiscountCalculator : ICampaignDiscountCalculator
    {
        public double Calculate(Campaign campaign, ShoppingCartProduct product)
        {
            return product.DiscountedPrice * campaign.Discount / 100;
        }
    }
}
