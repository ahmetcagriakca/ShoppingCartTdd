using System.Collections.Generic;
using ShoppingCart.UnitTests.Models;
using ShoppingCart.UnitTests.Models.Enums;

namespace ShoppingCart.UnitTests
{
    public class TestDataGenerator
    {
        /// <summary>
        /// Genereating Data for Shopping Cart discounts
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<object[]> GetShoppingCartInfos()
        {
            yield return new object[]
            {
                new List<ShoppingCartProduct>{
                    new ShoppingCartProduct( new Product ("Apple",100,new Category("food")),3),
                },
                new Campaign( new Category("food"),20.0, 3, DiscountType.Rate),
                new object[] { "Apple", 300.0, 240.0}
            };
            yield return new object[]
            {
                new List<ShoppingCartProduct>{
                    new ShoppingCartProduct( new Product ("Apple",100,new Category("food")),3),
                },
                new Campaign( new Category("food"),5.0, 5, DiscountType.Rate),
                new object[] { "Apple", 300.0, 300.0}
            };
            yield return new object[]
            {
                new List<ShoppingCartProduct>{
                    new ShoppingCartProduct( new Product ("Apple",100,new Category("food")),5),
                },
                new Campaign( new Category("food"),5.0, 5, DiscountType.Amount),
                new object[] { "Apple", 500.0, 475.0}
            };
            yield return new object[]
            {
                new List<ShoppingCartProduct>{
                    new ShoppingCartProduct( new Product ("Mouse",400,new Category("computer")),1),
                    new ShoppingCartProduct( new Product ("Apple",100,new Category("food")),5),
                },
                new Campaign( new Category("computer"),15.0, 1, DiscountType.Rate),
                new object[] { "Mouse", 900.0, 840.0}
            };
        }
    }
}