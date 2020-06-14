using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ShoppingCart.UnitTests.Domain.DeliveryManagement.Calculators;
using ShoppingCart.UnitTests.Domain.ShoppingCartManagement.Calculators;
using ShoppingCart.UnitTests.Domain.ShoppingCartManagement.Iterations;

namespace ShoppingCart.UnitTests.Models
{
    public class ShoppingCart
    {
        private readonly IDeliveryCostCalculator _deliveryCostCalculator;

        private readonly IDiscountIterator _discountIterator;

        #region Properties

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

        /// <summary>
        /// Number Of Deliveries is calculated by the number of distinct categories in the cart.
        /// </summary>
        public double NumberOfDeliveries => Products.GroupBy(en => en.Product.Category.Title).Count();

        /// <summary>
        /// NumberOfProducts is the number of different products in the cart
        /// Product added with title 
        /// </summary>
        public double NumberOfProducts => Products.Count;

        /// <summary>
        /// Get Delivery Cost
        /// </summary>
        private double DeliveryCost => _deliveryCostCalculator?.CalculateFor(this) ?? 0;
        #endregion Properties

        #region Constractor

        public ShoppingCart(IDiscountIterator discountIterator)
        {
            _discountIterator = discountIterator;
            Products = new List<ShoppingCartProduct>();
        }

        public ShoppingCart(IDiscountIterator discountIterator, IDeliveryCostCalculator deliveryCostCalculator) : this(discountIterator)
        {
            _deliveryCostCalculator = deliveryCostCalculator;
        }

        #endregion Constractor

        /// <summary>
        /// Add Product To Cart with Quantity
        /// </summary>
        /// <param name="product">Product</param>
        /// <param name="quantity">Product Quantity</param>
        public void AddItem(Product product, int quantity)
        {
            var productFound = Products.FirstOrDefault(en => en.Product.Title == product.Title);
            if (productFound != null)
            {
                productFound.Quantity += quantity;
            }
            else
            {
                Products.Add(new ShoppingCartProduct(product, quantity));
            }
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


        /// <summary>
        /// calculating delivery cost and return 
        /// </summary>
        public double GetDeliveryCost() => DeliveryCost;

        public string Print()
        {
            var productGroup = Products.GroupBy(en => en.Product.Category.Title).OrderBy(en => en.Key);
            var stringBuilder = new StringBuilder();
            var categoryName = "CategoryName";
            var productName = "ProductName";
            var quantity = "Quantity";
            var unitPrice = "Unit Price";
            var totalPrice = "Total Price";
            var totalDiscount = "Total Discount(coupon,campaign)applied";
            stringBuilder.AppendLine($"{categoryName,-20}{productName,-20}{quantity,-20}{unitPrice,-20}{totalPrice,-25}{totalDiscount,-40}");
            foreach (var group in productGroup)
            {
                var products = Products.Where(en => en.Product.Category.Title == group.Key)
                    .OrderBy(en => en.Product.Title);

                foreach (var product in products)
                {

                    stringBuilder.AppendLine($"{group.Key,-20}{product.Product.Title,-20}{product.Quantity,-20}{product.Product.Price,-20}{product.TotalPrice,-25}{product.DiscountedPrice,-40}");
                }


            }

            stringBuilder.AppendLine($@"Total Amount:{this.CartDiscountedPrice}");
            stringBuilder.AppendLine($@"Delivery Cost:{this.DeliveryCost}");
            return stringBuilder.ToString();
        }
    }
}