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
            var product = new Product(productTitle, price);
            Assert.Equal(product.Title, productTitle);
            Assert.Equal(product.Price, price);
        }
    }
}
