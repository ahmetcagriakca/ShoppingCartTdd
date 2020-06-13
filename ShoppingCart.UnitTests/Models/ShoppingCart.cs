using System.Collections.Generic;

namespace ShoppingCart.UnitTests.Models
{
    public class ShoppingCart
    {
        private ICollection<ShoppingCartProduct> Products { get; set; }

        public ShoppingCart()
        {
            Products = new List<ShoppingCartProduct>();
        }

        public void AddItem(Product product, int quantity)
        {
            Products.Add(new ShoppingCartProduct(product, quantity));
        }

        public ICollection<ShoppingCartProduct> GetItems() => Products;

        public int ItemCount() => Products.Count;
    }
}