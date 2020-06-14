namespace ShoppingCart.Domain.DeliveryManagement.Calculators
{
    public interface IDeliveryCostCalculator
    {
        double CalculateFor(Models.ShoppingCart cart);
    }
}
