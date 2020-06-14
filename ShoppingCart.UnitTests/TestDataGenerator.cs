using System.Collections.Generic;
using ShoppingCart.Domain.DeliveryManagement.Calculators;
using ShoppingCart.Domain.Models;
using ShoppingCart.Domain.Models.Enums;

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
                new object[] { "Apple", 300.0, 240.0, 60.0}
            };
            yield return new object[]
            {
                new List<ShoppingCartProduct>{
                    new ShoppingCartProduct( new Product ("Apple",100,new Category("food")),3),
                },
                new Campaign( new Category("food"),5.0, 5, DiscountType.Rate),
                new object[] { "Apple", 300.0, 300.0, 0.0 }
            };
            yield return new object[]
            {
                new List<ShoppingCartProduct>{
                    new ShoppingCartProduct( new Product ("Apple",100,new Category("food")),5),
                },
                new Campaign( new Category("food"),5.0, 5, DiscountType.Amount),
                new object[] { "Apple", 500.0, 475.0, 25.0 }
            };
            yield return new object[]
            {
                new List<ShoppingCartProduct>{
                    new ShoppingCartProduct( new Product ("Mouse",400,new Category("computer")),1),
                    new ShoppingCartProduct( new Product ("Apple",100,new Category("food")),5),
                },
                new Campaign( new Category("computer"),15.0, 1, DiscountType.Rate),
                new object[] { "Mouse", 900.0, 840.0, 60.0 }
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
                new List<ShoppingCartProduct>
                {
                    new ShoppingCartProduct(new Product("Mouse", 400, new Category("computer")), 1),
                    new ShoppingCartProduct(new Product("Apple", 100, new Category("food")), 3),
                },
                new List<Campaign>
                {
                    new Campaign(new Category("food"), 20.0, 3, DiscountType.Rate),
                    new Campaign(new Category("food"), 10.0, 2, DiscountType.Amount),
                    new Campaign(new Category("computer"), 15.0, 1, DiscountType.Rate),
                },
                new object[]
                {
                    700.0, //CartTotalPrice
                    550.0, //DiscountedPrice
                    150.0, //Campaigns Total Discount
                }
                //100*3 + 400*1 -(( 300*20%)+(10*3)+(400*15)) = 550
            };
            yield return new object[]
            {
                new List<ShoppingCartProduct>
                {
                    new ShoppingCartProduct(new Product("Mouse", 400, new Category("computer")), 1),
                    new ShoppingCartProduct(new Product("Almond", 150, new Category("food")), 2),
                    new ShoppingCartProduct(new Product("Apple", 100, new Category("food")), 3),
                    new ShoppingCartProduct(new Product("Banana", 200, new Category("food")), 5),
                },
                new List<Campaign>
                {
                    new Campaign(new Category("food"), 50.0, 5, DiscountType.Rate),
                    new Campaign(new Category("food"), 20.0, 3, DiscountType.Rate),
                    new Campaign(new Category("food"), 10.0, 2, DiscountType.Amount),
                    new Campaign(new Category("computer"), 15.0, 1, DiscountType.Rate),
                },
                new object[]
                {
                    2000.0, //CartTotalPrice
                    1180.0, //DiscountedPrice
                    820.0, //Campaigns Total Discount
                }
                //100*3 + 150*2 + 400*1 + 200*5  -( (1000*50%)+(300*20%)+(500*20%)+(10*2)+(10*3)+(10*5)+(400*15))=
            };
            yield return new object[]
            {
                new List<ShoppingCartProduct>
                {
                    new ShoppingCartProduct(new Product("Keyboard", 600, new Category("computer")), 3),
                    new ShoppingCartProduct(new Product("Mouse", 400, new Category("computer")), 1),
                    new ShoppingCartProduct(new Product("Almond", 150, new Category("food")), 2),
                    new ShoppingCartProduct(new Product("Apple", 100, new Category("food")), 3),
                    new ShoppingCartProduct(new Product("Banana", 200, new Category("food")), 5),
                },
                new List<Campaign>
                {
                    new Campaign(new Category("food"), 15.0, 2, DiscountType.Amount),
                    new Campaign(new Category("computer"), 30, 1, DiscountType.Amount),
                    new Campaign(new Category("food"), 50.0, 5, DiscountType.Rate),
                },
                new object[]
                {
                    3800.0, //CartTotalPrice
                    3030.0, //DiscountedPrice
                    770.0, //Campaigns Total Discount
                }
                //              Campaign 1  Campaign 2  Campaign 3   
                //Iteration 1   3650        3680        3300         campaign 3 applied
                //Iteration 2   3150        3180        X            campaign 1 applied
                //Iteration 3   X           3030        X            campaign 2 applied

            };
        }

        /// <summary>
        /// Genereating Data for Shopping Cart Multiple Campaign and coupon
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<object[]> GetShoppingCartMultipleCampaignsAndCoupon()
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
            new Coupon(1500,10,DiscountType.Rate),
            new object[] {
                700.0,//CartTotalPrice
                550.0,//DiscountedPrice
                550.0,//Cart Discounted After Coupon Price
                0.0,//Coupon Discounted Price
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
            new Coupon(1000,150,DiscountType.Amount),
            new object[]
            {
                2000.0,//CartTotalPrice
                1180.0,//DiscountedPrice
                1030.0,//Cart Discounted After Coupon Price
                150.0,//Coupon Discounted Price
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
            new Coupon(1500,10,DiscountType.Rate),
            new object[]
            {
                3800.0,//CartTotalPrice
                3030.0,//DiscountedPrice
                2727.0,//Cart Discounted After Coupon Price
                303.0,//Coupon Discounted Price
            }
            //              Campaign 1  Campaign 2  Campaign 3   
            //Iteration 1   3650        3680        3300         campaign 3 applied
            //Iteration 2   3150        3180        X            campaign 1 applied
            //Iteration 3   X           3030        X            campaign 2 applied

            };
        }

        /// <summary>
        /// Genereating Data for Shopping Cart Multiple Campaign and coupon
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<object[]> GetShoppingCartForDeliveryCost()
        {
            yield return new object[]
            {
            new List<ShoppingCartProduct>{
                new ShoppingCartProduct( new Product ("Mouse",400,new Category("computer")),1),
                new ShoppingCartProduct( new Product ("Apple",100,new Category("food")),3),
            },
            new DeliveryCostCalculator(5.0,1.0,2.99),
            new object[]
            {
                14.99,//Delivery Cost
            }
            // Delivery Cost = 5*2+1*2+2.99
            };
            yield return new object[]
            {
            new List<ShoppingCartProduct>{
                new ShoppingCartProduct( new Product ("Mouse",400,new Category("computer")),1),
                new ShoppingCartProduct( new Product ("Almond",150,new Category("food")),2),
                new ShoppingCartProduct( new Product ("Apple",100,new Category("food")),3),
                new ShoppingCartProduct( new Product ("Banana",200,new Category("food")),5),
            },
            new DeliveryCostCalculator(5.0,1.0,2.99),
            new object[]
            {
                16.99,//Delivery Cost
            }
            // Delivery Cost = 5*2+1*4+2.99
            };
            yield return new object[]
            {
            new List<ShoppingCartProduct>{
                new ShoppingCartProduct( new Product ("Keyboard",600,new Category("computer")),3),
                new ShoppingCartProduct( new Product ("Mouse",400,new Category("computer")),1),
                new ShoppingCartProduct( new Product ("Mouse",400,new Category("computer")),1),
                new ShoppingCartProduct( new Product ("Almond",150,new Category("food")),2),
                new ShoppingCartProduct( new Product ("Apple",100,new Category("food")),3),
                new ShoppingCartProduct( new Product ("Banana",200,new Category("food")),5),
            },
            new DeliveryCostCalculator(5.0,1.0,2.99),
            new object[]
            {
                17.99,//Delivery Cost
            }
            // Delivery Cost = 5*2+1*5+2.99
            };
        }

        /// <summary>
        /// Genereating Data for Shopping Cart Multiple Campaign and coupon
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<object[]> GetShoppingCartPrintTestValues()
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
            new Coupon(1500,10,DiscountType.Rate),
            new DeliveryCostCalculator(5.0,1.0,2.99),
            new object[]
            {
@"CategoryName        ProductName         Quantity            Unit Price          Total Price              Total Discount(coupon,campaign)applied  
computer            Mouse               1                   400                 400                      340                                     
food                Apple               3                   100                 300                      210                                     
Total Amount:700
Campaign Discount:150
Coupon Discount:0
Total Amount After Discounts:550
Delivery Cost:14.99
"
            }
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
            new Coupon(1000,150,DiscountType.Amount),
            new DeliveryCostCalculator(5.0,1.0,2.99),
            new object[]
            {
@"CategoryName        ProductName         Quantity            Unit Price          Total Price              Total Discount(coupon,campaign)applied  
computer            Mouse               1                   400                 400                      340                                     
food                Almond              2                   150                 300                      280                                     
food                Apple               3                   100                 300                      210                                     
food                Banana              5                   200                 1000                     350                                     
Total Amount:2000
Campaign Discount:820
Coupon Discount:150
Total Amount After Discounts:1030
Delivery Cost:16.99
"
            }
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
            new Coupon(1500,10,DiscountType.Rate),
            new DeliveryCostCalculator(5.0,1.0,2.99),
            new object[]
            {
@"CategoryName        ProductName         Quantity            Unit Price          Total Price              Total Discount(coupon,campaign)applied  
computer            Keyboard            3                   600                 1800                     1710                                    
computer            Mouse               1                   400                 400                      370                                     
food                Almond              2                   150                 300                      270                                     
food                Apple               3                   100                 300                      255                                     
food                Banana              5                   200                 1000                     425                                     
Total Amount:3800
Campaign Discount:770
Coupon Discount:303
Total Amount After Discounts:2727
Delivery Cost:17.99
"
            }
            };
        }
    }
}