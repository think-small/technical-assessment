using TechnicalAssessment.Models;

namespace TechnicalAssessment.Interfaces
{
    public interface ITaxRule
    {
        decimal CalculateTaxFor(Product product);
    }
}
