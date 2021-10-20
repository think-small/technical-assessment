using TechnicalAssessment.Models;

namespace TechnicalAssessment.Interfaces
{
    public interface ITaxService
    {
        decimal CalculateTaxesFor(Product product);
    }
}
