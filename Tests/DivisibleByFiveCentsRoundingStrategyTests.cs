using FluentAssertions;
using NUnit.Framework;
using TechnicalAssessment.Infrastructure;

namespace Tests
{
    [TestFixture]
    public class DivisibleByFiveCentsRoundingStrategyTests
    {
        [TestCase("1.01", "1.05")]
        [TestCase("1.56", "1.60")]
        [TestCase("1.55", "1.55")]
        [TestCase("20.00", "20.00")]
        public void Correctly_Rounds_Up_To_Nearest_Cent_That_Is_Divisible_By_Five(decimal input, decimal expected)
        {
            var rounder = new DivisibleByFiveCentsRoundingStrategy();

            var actual = rounder.Round(input);

            actual.Should().Be(expected);
        }
    }
}
