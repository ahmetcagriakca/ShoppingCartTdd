using ShoppingCart.UnitTests.Models;

namespace ShoppingCart.UnitTests.Domain.ShoppingCartManagement.Calculators
{
    public interface ICampaignDiscountCalculator
    {
        double Calculate(Campaign campaign, ShoppingCartProduct product);
    }
}
