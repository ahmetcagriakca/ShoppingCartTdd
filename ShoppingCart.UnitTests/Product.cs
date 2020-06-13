namespace ShoppingCart.UnitTests
{
    public class Product
    {
        public string Title { get; }
        public double Price { get; }

        public Product(string title, double price)
        {
            Title = title;
            Price = price;
        }
    }
}