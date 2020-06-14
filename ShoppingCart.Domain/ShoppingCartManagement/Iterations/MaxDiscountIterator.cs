using System.Collections.Generic;
using System.Linq;
using ShoppingCart.Domain.Models;

namespace ShoppingCart.Domain.ShoppingCartManagement.Iterations
{
    public class MaxDiscountIterator : IDiscountIterator
    {
        /// <summary>
        /// Found maximum discount for iteration 
        /// </summary>
        /// <param name="campaigns">Applied Campaigns </param>
        /// <param name="cart"></param>
        /// <returns>Best discounted campaign returns</returns>
        public Campaign Iterate(IEnumerable<Campaign> campaigns, Models.ShoppingCart cart)
        {
            var minimumTotalPrice = double.MaxValue;
            // Campaign ordered by discount type. If the amounts of the campaigns in Amount Discount type are the same as Rate Discount, the rate discount must be done first
            var orderedCampaigns = campaigns.OrderByDescending(en => en.DiscountType).ToList();
            // Best Discounted Campaign  initialized with first campaign
            Campaign bestDiscountedCampaign = orderedCampaigns.First();
            // Cart Products
            foreach (var campaign in orderedCampaigns)
            {
                CalculateCampaignExpectedDiscountValues(cart, campaign);
                // Expected Total price checked for best discount
                if (!(minimumTotalPrice > cart.ProductsExpectedDiscountedTotalPrice)) continue;

                minimumTotalPrice = cart.ProductsExpectedDiscountedTotalPrice;
                bestDiscountedCampaign = campaign;
            }

            // Best discounted campaign expected values calculating
            CalculateCampaignExpectedDiscountValues(cart, bestDiscountedCampaign);
            // Expected Discount Applied for products
            cart.ApplyExpectedDiscounts();
            return bestDiscountedCampaign;
        }

        /// <summary>
        /// finding campaign products in cart and Campaign expected discount calculation for this products
        /// </summary>
        /// <param name="cart"></param>
        /// <param name="campaign"></param>
        private void CalculateCampaignExpectedDiscountValues(Models.ShoppingCart cart, Campaign campaign)
        {
            //Clear Expected values for clean calculation
            cart.ClearExpectedValues();
            var appliedCampaignProducts =
                cart.GetItems().Where(en => en.Product.Category.Title == campaign.Category.Title).ToList();
            CalculateCampaignExpectedDiscountValues(appliedCampaignProducts, campaign);
        }

        /// <summary>
        /// Campaign expected discount calculation for products
        /// </summary>
        /// <param name="campaignProducts"></param>
        /// <param name="campaign"></param>
        private void CalculateCampaignExpectedDiscountValues(IEnumerable<ShoppingCartProduct> campaignProducts, Campaign campaign)
        {
            foreach (var product in campaignProducts)
            {

                if (product.Quantity < campaign.MinimumItemCount) continue;
                product.CalculateExpectedDiscount(campaign);
            }
        }
    }

}
