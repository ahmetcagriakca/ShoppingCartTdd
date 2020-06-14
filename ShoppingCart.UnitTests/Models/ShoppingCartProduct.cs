namespace ShoppingCart.UnitTests.Models
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
        public double ExpectedDiscountedPrice
        {
            get => _expectedDiscountedPrice ?? TotalPrice;
            set => _expectedDiscountedPrice = value;
        }

        public double TotalPrice => Product.Price * Quantity;


        public ShoppingCartProduct(Product product, int quantity)
        {
            Product = product;
            Quantity = quantity;
        }

        public void ApplyDiscount()
        {
            DiscountedPrice = ExpectedDiscountedPrice;
        }

        /// <summary>
        /// Expected Discount Calculated for campaign
        /// </summary>
        /// <param name="campaign">Applied campaign</param>
        public void CalculateExpectedDiscount(Campaign campaign)
        {
            ExpectedDiscountedPrice = campaign.CalculateDiscountForProduct(this);
        }

        /// <summary>
        /// Clear product expected discount values
        /// </summary>
        public void ClearExpectedValues()
        {
            ExpectedDiscountedPrice = DiscountedPrice;
        }
    }
}