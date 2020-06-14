using System.Collections.Generic;
using ShoppingCart.Domain.DeliveryManagement.Calculators;
using ShoppingCart.Domain.Models;
using ShoppingCart.Domain.Models.Enums;
using ShoppingCart.Domain.ShoppingCartManagement.Iterations;
using static System.Console;

namespace ShoppingCart.Console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool showMenu = true;
            while (showMenu)
            {
                showMenu = MainMenu();
            }
        }

        private static bool MainMenu()
        {
            WriteLine("Choose an option:");
            WriteLine("1) Show Example 1 ");
            WriteLine("2) Show Example 2");
            WriteLine("3) Show Example 3");
            WriteLine("0) Exit");
            Write("\r\nSelect an option: ");
            var key = ReadLine();
            Clear();
            switch (key)
            {
                case "1":
                    {
                        var shoppingCartProducts =
                            new List<ShoppingCartProduct>
                            {
                            new ShoppingCartProduct(new Product("Mouse", 400, new Category("computer")), 1),
                            new ShoppingCartProduct(new Product("Apple", 100, new Category("food")), 3),
                            };
                        var campaigns =
                            new List<Campaign>
                            {
                            new Campaign(new Category("food"), 20.0, 3, DiscountType.Rate),
                            new Campaign(new Category("food"), 10.0, 2, DiscountType.Amount),
                            new Campaign(new Category("computer"), 15.0, 1, DiscountType.Rate),
                            };
                        var coupon = new Coupon(1500, 10, DiscountType.Rate);

                        var deliveryCostCalculator = new DeliveryCostCalculator(5.0, 1.0, 2.99);
                        // Create new Shopping Cart
                        var cart = new Domain.Models.ShoppingCart(new MaxDiscountIterator(), deliveryCostCalculator);
                        // Products added to cart
                        foreach (var shoppingCartProduct in shoppingCartProducts)
                        {
                            cart.AddItem(shoppingCartProduct.Product, shoppingCartProduct.Quantity);
                        }

                        cart.ApplyDiscounts(campaigns.ToArray());
                        cart.ApplyCoupon(coupon);
                        var printText = cart.Print();
                        WriteLine(printText);
                    }
                    return true;
                case "2":
                    {
                        var shoppingCartProducts =
                            new List<ShoppingCartProduct>{
                                new ShoppingCartProduct( new Product ("Mouse",400,new Category("computer")),1),
                                new ShoppingCartProduct( new Product ("Almond",150,new Category("food")),2),
                                new ShoppingCartProduct( new Product ("Apple",100,new Category("food")),3),
                                new ShoppingCartProduct( new Product ("Banana",200,new Category("food")),5),
                            };
                        var campaigns =
                            new List<Campaign>
                            {
                                new Campaign( new Category("food"),50.0, 5, DiscountType.Rate),
                                new Campaign( new Category("food"),20.0, 3, DiscountType.Rate),
                                new Campaign( new Category("food"),10.0, 2, DiscountType.Amount),
                                new Campaign( new Category("computer"),15.0, 1, DiscountType.Rate),
                            };
                        var coupon = new Coupon(1000, 150, DiscountType.Amount);

                        var deliveryCostCalculator = new DeliveryCostCalculator(5.0, 1.0, 2.99);
                        // Create new Shopping Cart
                        var cart = new Domain.Models.ShoppingCart(new MaxDiscountIterator(), deliveryCostCalculator);
                        // Products added to cart
                        foreach (var shoppingCartProduct in shoppingCartProducts)
                        {
                            cart.AddItem(shoppingCartProduct.Product, shoppingCartProduct.Quantity);
                        }

                        cart.ApplyDiscounts(campaigns.ToArray());
                        cart.ApplyCoupon(coupon);
                        var printText = cart.Print();
                        WriteLine(printText);
                    }
                    return true;
                case "3":
                    {
                        var shoppingCartProducts =
                            new List<ShoppingCartProduct>{
                                new ShoppingCartProduct( new Product ("Keyboard",600,new Category("computer")),3),
                                new ShoppingCartProduct( new Product ("Mouse",400,new Category("computer")),1),
                                new ShoppingCartProduct( new Product ("Almond",150,new Category("food")),2),
                                new ShoppingCartProduct( new Product ("Apple",100,new Category("food")),3),
                                new ShoppingCartProduct( new Product ("Banana",200,new Category("food")),5),
                            };
                        var campaigns =
                            new List<Campaign>
                            {
                                new Campaign( new Category("food"),15.0, 2, DiscountType.Amount),
                                new Campaign( new Category("computer"),30, 1, DiscountType.Amount),
                                new Campaign( new Category("food"),50.0, 5, DiscountType.Rate),
                            };
                        var coupon = new Coupon(1500, 10, DiscountType.Rate);

                        var deliveryCostCalculator = new DeliveryCostCalculator(5.0, 1.0, 2.99);
                        // Create new Shopping Cart
                        var cart = new Domain.Models.ShoppingCart(new MaxDiscountIterator(), deliveryCostCalculator);
                        // Products added to cart
                        foreach (var shoppingCartProduct in shoppingCartProducts)
                        {
                            cart.AddItem(shoppingCartProduct.Product, shoppingCartProduct.Quantity);
                        }

                        cart.ApplyDiscounts(campaigns.ToArray());
                        cart.ApplyCoupon(coupon);
                        var printText = cart.Print();
                        WriteLine(printText);
                    }
                    return true;
                case "0":
                    return false;
                default:
                    return true;
            }

        }
    }
}
