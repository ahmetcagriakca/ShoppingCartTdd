using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ShoppingCart.UnitTests.Models.Enums;

namespace ShoppingCart.UnitTests.Models
{
    public class ShoppingCart
    {
        private ICollection<ShoppingCartProduct> Products { get; set; }

        public double TotalPrice => Products.Sum(product => product.TotalPrice);
        public double DiscountedTotalPrice => Products.Sum(product => product.DiscountedPrice);

        public ShoppingCart()
        {
            Products = new List<ShoppingCartProduct>();
        }

        public void AddItem(Product product, int quantity)
        {
            Products.Add(new ShoppingCartProduct(product, quantity));
        }

        public ICollection<ShoppingCartProduct> GetItems() => Products;

        public int ItemCount() => Products.Count;

        public void ApplyDiscount(Campaign campaign)
        {
            var campaignProducts = Products.Where(en => en.Product.Category.Title == campaign.Category.Title).ToList();
            //Apply discount on items if category item count bigger than campaign minimum item count
            if (campaignProducts.Sum(en => en.Quantity) < campaign.MinimumItemCount) return;

            foreach (var product in campaignProducts)
            {
                switch (campaign.DiscountType)
                {
                    case DiscountType.Rate:
                        product.DiscountedPrice = product.TotalPrice - product.TotalPrice * campaign.Discount / 100;
                        break;
                    case DiscountType.Amount:
                        product.DiscountedPrice = product.TotalPrice - campaign.Discount * product.Quantity;
                        break;
                }

            }
        }
    }
}