using TechnicalAssessment.Interfaces;
using TechnicalAssessment.Models;

namespace TechnicalAssessment.Infrastructure
{
    public class BaseSaleTaxRule : ITaxRule
    {
        private readonly decimal _taxRate = 0.1M;
        public decimal CalculateTaxFor(Product product)
        {
            if (IsExempt(product)) return decimal.Zero;

            return product.Price * _taxRate;
        }

        private bool IsExempt(Product product)
        {
            return product.ProductType == ProductType.Books
                || product.ProductType == ProductType.Food
                || product.ProductType == ProductType.Medicine;
        }
    }
}
