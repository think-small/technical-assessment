using FluentAssertions;
using NUnit.Framework;
using TechnicalAssessment.Infrastructure;
using TechnicalAssessment.Interfaces;
using TechnicalAssessment.Models;

namespace Tests
{
    [TestFixture]
    public class ImportSaleTaxTests
    {
        ITaxRule taxRule;
        [SetUp]
        public void Init()
        {
            taxRule = new ImportSaleTaxRule();
        }
        [Test]
        public void Returns_Five_Percent_Of_Imported_Product_Price()
        {
            var product = new Product
            {
                Name = "Test",
                Price = 100.00M,
                IsImported = true,
                ProductType = ProductType.Food,
            };

            var actual = taxRule.CalculateTaxFor(product);

            actual.Should().Be(5.00M);
        }

        [Test]
        public void Returns_Zero_For_Non_Imported_Product()
        {
            var product = new Product
            {
                Name = "Test",
                Price = 1500.25M,
                IsImported = false,
                ProductType = ProductType.Media
            };

            var actual = taxRule.CalculateTaxFor(product);

            actual.Should().Be(decimal.Zero);
        }
    }
}
