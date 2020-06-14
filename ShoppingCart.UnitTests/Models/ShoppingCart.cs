using System.Collections.Generic;
using System.Linq;
using ShoppingCart.UnitTests.Domain.ShoppingCartManagement.Calculators;
using ShoppingCart.UnitTests.Domain.ShoppingCartManagement.Iterations;

namespace ShoppingCart.UnitTests.Models
{
    public class ShoppingCart
    {
        private readonly IDiscountIterator _discountIterator;
        private double? _cartDiscountedPrice;
        private ICollection<ShoppingCartProduct> Products { get; set; }

        public double CartTotalPrice => Products.Sum(product => product.TotalPrice);

        public double CartDiscountedPrice
        {
            get => _cartDiscountedPrice ?? ProductsDiscountedTotalPrice;
            set => _cartDiscountedPrice = value;
        }

        public double ProductsDiscountedTotalPrice => Products.Sum(product => product.DiscountedPrice);

        /// <summary>
        ///  Shopping Cart Products Expected Discounted Total Price
        /// </summary>
        public double ProductsExpectedDiscountedTotalPrice => Products.Sum(product => product.ExpectedDiscountedPrice);

        public ShoppingCart(IDiscountIterator discountIterator)
        {
            _discountIterator = discountIterator;
            Products = new List<ShoppingCartProduct>();
        }

        /// <summary>
        /// Add Product To Cart with Quantity
        /// </summary>
        /// <param name="product">Product</param>
        /// <param name="quantity">Product Quantity</param>
        public void AddItem(Product product, int quantity)
        {
            Products.Add(new ShoppingCartProduct(product, quantity));
        }

        /// <summary>
        /// Get Cart Products
        /// </summary>
        /// <returns></returns>
        public ICollection<ShoppingCartProduct> GetItems() => Products;

        /// <summary>
        /// Get Products Count
        /// </summary>
        /// <returns></returns>
        public int ItemCount() => Products.Count;

        /// <summary>
        /// Clear Product expected values in cart
        /// </summary>
        public void ClearExpectedValues()
        {
            foreach (var product in Products)
            {
                product.ClearExpectedValues();
            }
        }

        /// <summary>
        /// Clear Product expected values in cart
        /// </summary>
        public void ApplyExpectedDiscounts()
        {
            foreach (var product in Products)
            {
                product.ApplyDiscount();
            }
        }

        /// <summary>
        /// Apply Discount with iteration
        /// </summary>
        /// <param name="campaigns">Campaigns discount </param>
        public void ApplyDiscounts(params Campaign[] campaigns)
        {
            var lengthOfIteration = campaigns.Length;
            var appliedCampaigns = campaigns.ToList();
            for (var i = 0; i < lengthOfIteration; i++)
            {
                var campaign = _discountIterator.Iterate(appliedCampaigns, this);
                appliedCampaigns.Remove(campaign);
            }
        }

        /// <summary>
        /// Applying coupon discount
        /// </summary>
        /// <param name="coupon"></param>
        public void ApplyCoupon(Coupon coupon)
        {
            CartDiscountedPrice = coupon.CalculateDiscountForCart(ProductsDiscountedTotalPrice);
        }
    }
}