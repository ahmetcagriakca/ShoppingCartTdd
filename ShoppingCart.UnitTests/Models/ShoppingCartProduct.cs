namespace ShoppingCart.UnitTests.Models
{
    public class ShoppingCartProduct
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }

        public ShoppingCartProduct(Product product, int quantity)
        {
            Product = product;
            Quantity = quantity;
        }
    }
}