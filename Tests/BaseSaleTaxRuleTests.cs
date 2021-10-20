using FluentAssertions;
using NUnit.Framework;
using TechnicalAssessment.Infrastructure;
using TechnicalAssessment.Interfaces;
using TechnicalAssessment.Models;

namespace Tests
{
    [TestFixture]
    public class BaseSaleTaxRuleTests
    {
        ITaxRule taxRule;
        [SetUp]
        public void Init()
        {
            taxRule = new BaseSaleTaxRule();
        }
        [Test]
        public void Returns_Ten_Percent_Of_Product_Price()
        {
            var product = new Product
            {
                Name = "Test",
                Price = 10.00M,
                IsImported = false,
                ProductType = ProductType.Beauty
            };

            var actual = taxRule.CalculateTaxFor(product);

            actual.Should().Be(1.00M);
        }

        [Test]
        public void Returns_Zero_If_Product_Is_Exempt()
        {
            var product = new Product
            {
                Name = "Test",
                Price = 1000.50M,
                IsImported = false,
                ProductType = ProductType.Books
            };

            var actual = taxRule.CalculateTaxFor(product);

            actual.Should().Be(decimal.Zero);
        }
    }
}
