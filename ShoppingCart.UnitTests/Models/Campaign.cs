namespace ShoppingCart.UnitTests.Models
{
    public class Campaign
    {
        public Category Category { get; }

        public Campaign(Category category)
        {
            Category = category;
        }
    }
}