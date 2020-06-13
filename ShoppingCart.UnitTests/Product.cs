namespace ShoppingCart.UnitTests
{
    public class Product
    {
        public string Title { get; }
        public double Price { get; }
        public Category Category { get; }

        public Product(string title, in double price, Category category)
        {
            Title = title;
            Price = price;
            Category = category;
        }
    }
}