using ShoppingCart.UnitTests.Models;

namespace ShoppingCart.UnitTests.Domain.ShoppingCartManagement.Calculators
{
    public class CampaignAmountDiscountCalculator : ICampaignDiscountCalculator
    {
        public double Calculate(Campaign campaign, ShoppingCartProduct product)
        {
            return product.DiscountedPrice - product.Quantity * campaign.Discount ;
        }
    }
}
