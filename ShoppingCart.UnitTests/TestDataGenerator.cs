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
        /// <summary>
        /// Genereating Data for Shopping Cart Multiple Campaign
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<object[]> GetShoppingCartMultipleCampaignsInfos()
        {
            yield return new object[]
            {
                new List<ShoppingCartProduct>{
                    new ShoppingCartProduct( new Product ("Mouse",400,new Category("computer")),1),
                    new ShoppingCartProduct( new Product ("Apple",100,new Category("food")),3),
                },
                new List<Campaign>
                {
                    new Campaign( new Category("food"),20.0, 3, DiscountType.Rate),
                    new Campaign( new Category("food"),10.0, 2, DiscountType.Amount),
                    new Campaign( new Category("computer"),15.0, 1, DiscountType.Rate),
                },
                new object[] { 
                    700.0,//TotalPrice
                    550.0,//DiscountedPrice
                }
                //100*3 + 400*1 -(( 300*20%)+(10*3)+(400*15)) = 550
            };
            yield return new object[]
            {
                new List<ShoppingCartProduct>{
                    new ShoppingCartProduct( new Product ("Mouse",400,new Category("computer")),1),
                    new ShoppingCartProduct( new Product ("Almond",150,new Category("food")),2),
                    new ShoppingCartProduct( new Product ("Apple",100,new Category("food")),3),
                    new ShoppingCartProduct( new Product ("Banana",200,new Category("food")),5),
                },
                new List<Campaign>
                {
                    new Campaign( new Category("food"),50.0, 5, DiscountType.Rate),
                    new Campaign( new Category("food"),20.0, 3, DiscountType.Rate),
                    new Campaign( new Category("food"),10.0, 2, DiscountType.Amount),
                    new Campaign( new Category("computer"),15.0, 1, DiscountType.Rate),
                },
                new object[]
                {
                    2000.0,//TotalPrice
                    1180.0,//DiscountedPrice
                }
                //100*3 + 150*2 + 400*1 + 200*5  -( (1000*50%)+(300*20%)+(500*20%)+(10*2)+(10*3)+(10*5)+(400*15))=
            };
            yield return new object[]
            {
                new List<ShoppingCartProduct>{
                    new ShoppingCartProduct( new Product ("Keyboard",600,new Category("computer")),3),
                    new ShoppingCartProduct( new Product ("Mouse",400,new Category("computer")),1),
                    new ShoppingCartProduct( new Product ("Almond",150,new Category("food")),2),
                    new ShoppingCartProduct( new Product ("Apple",100,new Category("food")),3),
                    new ShoppingCartProduct( new Product ("Banana",200,new Category("food")),5),
                },
                new List<Campaign>
                {
                    new Campaign( new Category("food"),15.0, 2, DiscountType.Amount),
                    new Campaign( new Category("computer"),30, 1, DiscountType.Amount),
                    new Campaign( new Category("food"),50.0, 5, DiscountType.Rate),
                },
                new object[]
                {
                    3800.0,//TotalPrice
                    3030.0,//DiscountedPrice
                }
                //              Campaign 1  Campaign 2  Campaign 3   
                //Iteration 1   3650        3680        3300         campaign 3 applied
                //Iteration 2   3150        3180        X            campaign 1 applied
                //Iteration 3   X           3030        X            campaign 2 applied

            };
        }
    }
}