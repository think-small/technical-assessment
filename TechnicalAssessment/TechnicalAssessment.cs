using System;
using System.Collections.Generic;
using TechnicalAssessment.Interfaces;
using TechnicalAssessment.Models;

namespace TechnicalAssessment
{
    public class TechnicalAssessment
    {
        private readonly ITaxService _taxService;
        public TechnicalAssessment(ITaxService taxService)
        {
            _taxService = taxService;
        }
        public void Run() 
        {
            Console.WriteLine("Output 1:");
            var basketOne = CreateBasketOne();
            basketOne.CalculateTotal();
            basketOne.PrintReceipt();

            Console.WriteLine("Output 2:");
            var basketTwo = CreateBasketTwo();
            basketTwo.CalculateTotal();
            basketTwo.PrintReceipt();

            Console.WriteLine("Output 3:");
            var basketThree = CreateBasketThree();
            basketThree.CalculateTotal();
            basketThree.PrintReceipt();

            Console.ReadKey();
        }

        Basket CreateBasketOne()
        {
            var items = new List<BasketItem>
            {
                new BasketItem
                {
                    Quantity = 1,
                    Product = new Product
                    {
                        Name = "book",
                        Price = 12.49M,
                        IsImported = false,
                        ProductType = ProductType.Books
                    }
                },
                new BasketItem
                {
                    Quantity = 1,
                    Product = new Product
                    {
                        Name = "music CD",
                        Price = 14.99M,
                        IsImported = false,
                        ProductType = ProductType.Media
                    }
                },
                new BasketItem
                {
                    Quantity = 1,
                    Product = new Product
                    {
                        Name = "chocolate bar",
                        Price = 0.85M,
                        IsImported = false,
                        ProductType = ProductType.Food
                    }
                }
            };
            return new Basket(_taxService, items);
        }

        Basket CreateBasketTwo()
        {
            var items = new List<BasketItem>
            {
                new BasketItem
                {
                    Quantity = 1,
                    Product = new Product
                    {
                        Name = "box of chocolates",
                        Price = 10.00M,
                        IsImported = true,
                        ProductType = ProductType.Food
                    }
                },
                new BasketItem
                {
                    Quantity = 1,
                    Product = new Product
                    {
                        Name = "bottle of perfume",
                        Price = 47.50M,
                        IsImported = true,
                        ProductType = ProductType.Beauty
                    }
                }
            };
            return new Basket(_taxService, items);
        }

        Basket CreateBasketThree()
        {
            var items = new List<BasketItem>
            {
                new BasketItem
                {
                    Quantity = 1,
                    Product = new Product
                    {
                        Name = "bottle of perfume",
                        Price = 27.99M,
                        IsImported = true,
                        ProductType = ProductType.Beauty
                    }
                },
                new BasketItem
                {
                    Quantity = 1,
                    Product = new Product
                    {
                        Name = "bottle of perfume",
                        Price = 18.99M,
                        IsImported = false,
                        ProductType = ProductType.Beauty
                    }
                },
                new BasketItem
                {
                    Quantity = 1,
                    Product = new Product
                    {
                        Name = "packet of headache pills",
                        Price = 9.75M,
                        IsImported = false,
                        ProductType = ProductType.Medicine
                    }
                },
                new BasketItem
                {
                    Quantity = 1,
                    Product = new Product
                    {
                        Name = "box of chocolates",
                        Price = 11.25M,
                        IsImported = true,
                        ProductType = ProductType.Food
                    }
                }
            };
            return new Basket(_taxService, items);
        }
    }
}
