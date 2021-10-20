using System;
using TechnicalAssessment.Interfaces;

namespace TechnicalAssessment.Infrastructure
{
    public class DivisibleByFiveCentsRoundingStrategy : IRoundingStrategy
    {
        public decimal Round(decimal value)
        {
            decimal increment = 0.01M;
            decimal result = DecimalToHundrethsPlace(value);

            while (IsDivisibleByFiveCents(result) == false)
            {
                result += increment;
            }
            return result;
        }

        private decimal DecimalToHundrethsPlace(decimal value)
        {
            return Math.Truncate(100 * value) / 100;
        }

        private bool IsDivisibleByFiveCents(decimal value)
        {
            decimal divisor = 0.05M;
            return value % divisor == 0;
        }
    }
}
