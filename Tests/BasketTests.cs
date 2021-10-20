using FluentAssertions;
using NUnit.Framework;
using System.Collections.Generic;
using TechnicalAssessment.Infrastructure;
using TechnicalAssessment.Interfaces;
using TechnicalAssessment.Models;
using TechnicalAssessment.Services;

namespace Tests
{
    [TestFixture]
    public class BasketTests
    {
        Basket basket;
        [SetUp]
        public void Init()
        {
            var taxRules = new List<ITaxRule>
            {
                new BaseSaleTaxRule(), new ImportSaleTaxRule()
            };
            var rounder = new DivisibleByFiveCentsRoundingStrategy();
            var taxService = new TaxService(taxRules, rounder);
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
            basket = new Basket(taxService, items);
        }

        [Test]
        public void Calculates_Correct_Sales_Tax_And_Grand_Total_For_Basket()
        {
            basket.CalculateTotal();

            basket.TotalTax.Should().Be(6.70M);
            basket.GrandTotal.Should().Be(74.68M);
        }

        [Test]
        public void Items_In_Basket_Have_Correct_Sales_Tax_And_Total_Cost()
        {
            basket.CalculateTotal();

            basket.Items[0].Tax.Should().Be(4.20M);
            basket.Items[0].Cost.Should().Be(32.19M);

            basket.Items[1].Tax.Should().Be(1.90M);
            basket.Items[1].Cost.Should().Be(20.89M);

            basket.Items[2].Tax.Should().Be(decimal.Zero);
            basket.Items[2].Cost.Should().Be(9.75M);

            basket.Items[3].Tax.Should().Be(0.60M);
            basket.Items[3].Cost.Should().Be(11.85M);
        }
    }
}
