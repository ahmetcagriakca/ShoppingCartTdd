namespace ShoppingCart.UnitTests.Models
{
    public class Category
    {
        public string Title { get; }
        public Category ParentCategory { get; }

        public Category(string title)
        {
            Title = title;
        }

        public Category(string title, Category parentCategory)
        {
            Title = title;
            ParentCategory = parentCategory;
        }
    }
}