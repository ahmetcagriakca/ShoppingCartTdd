using ShoppingCart.Domain.Models;

namespace ShoppingCart.Domain.ShoppingCartManagement.Calculators
{
    public interface ICampaignDiscountCalculator
    {
        double Calculate(Campaign campaign, ShoppingCartProduct product);
    }
}
