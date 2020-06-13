using System;
using Xunit;

namespace ShoppingCart.UnitTests
{
    public class ShoppingCartTests
    {

        /// <summary>
        /// product creating and informations check
        /// </summary>
        [Theory]
        [InlineData("Apple", 100)]
        public void Create_Product(string productTitle, double price)
        {
            //Category created for product
            var category = new Category();
            // Product create with category
            var product = new Product(productTitle, price, category);
            Assert.Equal(product.Title, productTitle);
            Assert.Equal(product.Price, price);
            Assert.Equal(product.Category, category);
        }

        /// <summary>
        /// Category create 
        /// </summary>
        [Fact]
        public void Create_Category()
        {
            var category = new Category();
            Assert.NotNull(category);
        }
    }
}
