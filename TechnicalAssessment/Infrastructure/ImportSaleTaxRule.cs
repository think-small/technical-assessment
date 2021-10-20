using TechnicalAssessment.Interfaces;
using TechnicalAssessment.Models;

namespace TechnicalAssessment.Infrastructure
{
    public class ImportSaleTaxRule : ITaxRule
    {
        private readonly decimal _taxRate = 0.05M;
        public decimal CalculateTaxFor(Product product)
        {
            if (product.IsImported == false) return decimal.Zero;

            return product.Price * _taxRate;
        }
    }
}
