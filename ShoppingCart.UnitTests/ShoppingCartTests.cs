using System;
using Xunit;
using System.Linq;

namespace ShoppingCart.UnitTests
{
    public class ShoppingCartTests
    {

        /// <summary>
        /// product creating and informations check
        /// </summary>
        [Theory]
        [InlineData("Apple", 100, "food")]
        public void Create_Product(string productTitle, double price, string categoryTitle)
        {
            //Category created for product
            var category = new Category(categoryTitle);
            // Product create with category
            var product = new Product(productTitle, price, category);
            Assert.Equal(product.Title, productTitle);
            Assert.Equal(product.Price, price);
            Assert.Equal(product.Category, category);
            Assert.Equal(product.Category.Title, categoryTitle);
        }

        /// <summary>
        /// Category create 
        /// </summary>
        [Theory]
        [InlineData("food")]
        public void Create_Category(string title)
        {
            var category = new Category(title);
            Assert.NotNull(category);
            Assert.Equal(category.Title, title);
        }

        /// <summary>
        /// Create Category with parent category
        /// </summary>
        [Theory]
        [InlineData("food", "market")]
        public void Create_CategoryWithParent(string title, string parentCategoryTitle)
        {
            var parentCategory = new Category(parentCategoryTitle);
            var category = new Category(title, parentCategory);
            Assert.Equal(category.ParentCategory, parentCategory);
            Assert.Equal(category.ParentCategory.Title, parentCategoryTitle);
        }
    }
}
