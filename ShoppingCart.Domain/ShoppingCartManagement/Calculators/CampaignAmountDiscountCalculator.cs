using ShoppingCart.Domain.Models;

namespace ShoppingCart.Domain.ShoppingCartManagement.Calculators
{
    public class CampaignAmountDiscountCalculator : ICampaignDiscountCalculator
    {
        public double Calculate(Campaign campaign, ShoppingCartProduct product)
        {
            return product.Quantity * campaign.Discount ;
        }
    }
}
