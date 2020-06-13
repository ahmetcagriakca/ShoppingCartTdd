using System;
using Xunit;
using System.Linq;
using ShoppingCart.UnitTests.Models;

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

        /// <summary>
        /// Add product to shopping cart with quantity
        /// </summary>
        [Theory]
        [InlineData("food", "Apple", 100, 3)]
        [InlineData("food", "Almond", 150, 3)]
        public void Add_Product_To_ShoppingCart(string categoryTitle, string productTitle, double productPrice, int quantity)
        {
            // Category create
            var category = new Category(categoryTitle);
            // Product create with category
            var product = new Product(productTitle, productPrice, category);
            // Create new Shopping Cart
            var cart = new Models.ShoppingCart();
            // New Item added to cart
            cart.AddItem(product, quantity);
            Assert.True(cart.ItemCount() == 1);
            Assert.True(cart.GetItems().First().Product == product);
            Assert.True(cart.GetItems().First().Quantity == quantity);
        }

        /// <summary>
        /// Create Campaign
        /// Campaign applicable for a category
        /// </summary>
        [Theory]
        [InlineData("food")]
        public void Create_Campaign(string categoryTitle)
        {
            var category = new Category(categoryTitle);
            var campaign = new Campaign(category);
            Assert.NotNull(campaign);
            Assert.Equal(campaign.Category.Title, categoryTitle);
        }
    }
}
