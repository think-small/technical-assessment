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
    public class TaxServiceTests
    {
        ITaxService taxService;
        [SetUp]
        public void Init()
        {
            List<ITaxRule> taxRules = new List<ITaxRule>
            {
                new BaseSaleTaxRule(), new ImportSaleTaxRule()
            };
            IRoundingStrategy rounder = new DivisibleByFiveCentsRoundingStrategy();
            taxService = new TaxService(taxRules, rounder);
        }

        [Test]
        public void Applies_Base_And_Import_Taxes_To_Imported_Media()
        {
            var product = new Product
            {
                Name = "Test",
                Price = 100.00M,
                IsImported = true,
                ProductType = ProductType.Media
            };

            var actual = taxService.CalculateTaxesFor(product);

            actual.Should().Be(15.00M);
        }

        [Test]
        public void Applies_Only_Base_Tax_To_Non_Imported_Beauty_Product()
        {
            var product = new Product
            {
                Name = "Test",
                Price = 100.00M,
                IsImported = false,
                ProductType = ProductType.Beauty
            };

            var actual = taxService.CalculateTaxesFor(product);

            actual.Should().Be(10.00M);
        }

        [Test]
        public void Applies_Only_Import_Tax_To_Imported_Medicine()
        {
            var product = new Product
            {
                Name = "Test",
                Price = 100.00M,
                IsImported = true,
                ProductType = ProductType.Medicine
            };

            var actual = taxService.CalculateTaxesFor(product);

            actual.Should().Be(5.00M);
        }

        [Test]
        public void Applies_No_Tax_To_Non_Imported_Book()
        {
            var product = new Product
            {
                Name = "Test",
                Price = 100.00M,
                IsImported = false,
                ProductType = ProductType.Books
            };

            var actual = taxService.CalculateTaxesFor(product);

            actual.Should().Be(decimal.Zero);
        }
    }
}
