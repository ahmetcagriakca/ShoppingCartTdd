namespace ShoppingCart.UnitTests
{
    public class Category
    {
        public Category ParentCategory { get; }

        public Category()
        {
        }

        public Category(Category parentCategory)
        {
            ParentCategory = parentCategory;
        }
    }
}