using System.Collections.Generic;
using TechnicalAssessment.Interfaces;
using TechnicalAssessment.Models;

namespace TechnicalAssessment.Services
{
    public class TaxService : ITaxService
    {
        private readonly IEnumerable<ITaxRule> _taxRules;
        private readonly IRoundingStrategy _rounder;
        public TaxService(IEnumerable<ITaxRule> taxRules, IRoundingStrategy rounder)
        {
            _taxRules = taxRules;
            _rounder = rounder;
        }
        public decimal CalculateTaxesFor(Product product)
        {
            decimal totalTax = decimal.Zero;
            foreach (var taxRule in _taxRules)
            {
                decimal tax = taxRule.CalculateTaxFor(product);
                totalTax += _rounder.Round(tax);
            }
            return totalTax;
        }
    }
}
