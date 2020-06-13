namespace ShoppingCart.UnitTests.Models
{
    public class ShoppingCartProduct
    {
        private double? _discountedPrice;
        public Product Product { get; set; }

        public int Quantity { get; set; }

        public double DiscountedPrice
        {
            get => _discountedPrice ?? TotalPrice;
            set => _discountedPrice = value;
        }

        public double TotalPrice => Product.Price * Quantity;


        public ShoppingCartProduct(Product product, int quantity)
        {
            Product = product;
            Quantity = quantity;
        }

    }
}