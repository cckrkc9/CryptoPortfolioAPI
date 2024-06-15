using PortfolioAppDemo.Utilities.Formatters;

namespace PortfolioAppDemo.Extensions
{
    public static class IMvcBuilderExtensions
    {
        public static IMvcBuilder AddCustomCsvFormatter(this IMvcBuilder builder) =>
            builder.AddMvcOptions(config =>
                config.OutputFormatters
                .Add(new CsvOutputFormatter()));
    }
}
