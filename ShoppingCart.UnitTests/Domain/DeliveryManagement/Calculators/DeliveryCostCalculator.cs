using System;

namespace ShoppingCart.UnitTests.Domain.DeliveryManagement.Calculators
{
    public class DeliveryCostCalculator : IDeliveryCostCalculator
    {
        public double CostPerDelivery { get; }
        public double CostPerProduct { get; }
        public double FixedCost { get; }

        public DeliveryCostCalculator(double costPerDelivery, double costPerProduct, double fixedCost)
        {
            CostPerDelivery = costPerDelivery;
            CostPerProduct = costPerProduct;
            FixedCost = fixedCost;
        }

        /// <summary>
        /// Calculating Delivery Cost for cart
        /// </summary>
        /// <param name="cart"></param>
        /// <returns></returns>
        public double CalculateFor(Models.ShoppingCart cart)
        {
            return Math.Round((CostPerDelivery * cart.NumberOfDeliveries) + (CostPerProduct * cart.NumberOfProducts) + FixedCost, 2);
        }
    }
}
