namespace ShoppingCart.Domain.Models
{
    public class Category
    {
        public string Title { get; }
        public Category ParentCategory { get; }

        public Category(string title) : this(title, null)
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