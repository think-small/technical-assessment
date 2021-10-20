using Autofac;
using TechnicalAssessment.Infrastructure;
using TechnicalAssessment.Interfaces;
using TechnicalAssessment.Services;

namespace TechnicalAssessment
{
    class Program
    {
        static void Main(string[] args)
        {
            BuildContainer().Resolve<TechnicalAssessment>().Run();
        }

        private static IContainer BuildContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<TechnicalAssessment>();
            builder.RegisterType<TaxService>().As<ITaxService>();
            builder.RegisterType<DivisibleByFiveCentsRoundingStrategy>().As<IRoundingStrategy>();
            builder.RegisterType<BaseSaleTaxRule>().As<ITaxRule>();
            builder.RegisterType<ImportSaleTaxRule>().As<ITaxRule>();

            return builder.Build();
        }
    }
}
