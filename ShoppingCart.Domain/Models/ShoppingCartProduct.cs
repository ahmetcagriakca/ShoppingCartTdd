using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingCart.Domain.Models
{
    public class ShoppingCartProduct
    {
        public Product Product { get; set; }

        public int Quantity { get; set; }

        private double? _discountedPrice;

        public double DiscountedPrice
        {
            get => _discountedPrice ?? TotalPrice;
            set => _discountedPrice = value;
        }

        private double? _expectedDiscountedPrice;

        public double ExpectedDiscountedTotalPrice
        {
            get => _expectedDiscountedPrice ?? TotalPrice;
            set => _expectedDiscountedPrice = value;
        }

        public double TotalPrice => Product.Price * Quantity;

        public List<Tuple<Campaign, double>> AppliedCampaignDiscounts { get; set; }
        public Tuple<Campaign, double> ExpectedCampaignDiscount { get; set; }
        public double CampaignsTotalDiscount => AppliedCampaignDiscounts.Sum(en=> en.Item2);

        public ShoppingCartProduct(Product product, int quantity)
        {
            Product = product;
            Quantity = quantity;
            AppliedCampaignDiscounts = new List<Tuple<Campaign, double>>();
            ExpectedCampaignDiscount = null;
        }

        /// <summary>
        /// apply expected discount for product
        /// </summary>
        public void ApplyDiscount()
        {
            if (ExpectedCampaignDiscount == null) return;
            DiscountedPrice = ExpectedDiscountedTotalPrice;
            AppliedCampaignDiscounts.Add(ExpectedCampaignDiscount);
        }

        /// <summary>
        /// Expected Discount Calculated for campaign
        /// </summary>
        /// <param name="campaign">Applied campaign</param>
        public void CalculateExpectedDiscount(Campaign campaign)
        {
            var campaignDiscount = campaign.CalculateDiscountForProduct(this);
            ExpectedDiscountedTotalPrice -= campaignDiscount;
            ExpectedCampaignDiscount = new Tuple<Campaign, double>(campaign, campaignDiscount);
        }

        /// <summary>
        /// Clear product expected discount values
        /// </summary>
        public void ClearExpectedValues()
        {
            ExpectedDiscountedTotalPrice = DiscountedPrice;
            ExpectedCampaignDiscount = null;
        }
    }
}