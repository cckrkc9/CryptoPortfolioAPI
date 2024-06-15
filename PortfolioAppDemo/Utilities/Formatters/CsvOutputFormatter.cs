using Entities.DataTransferObjects;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Net.Http.Headers;
using System.Text;

namespace PortfolioAppDemo.Utilities.Formatters
{
    public class CsvOutputFormatter : TextOutputFormatter
    {
        public CsvOutputFormatter()
        {
            SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse("text/csv"));
            SupportedEncodings.Add(Encoding.UTF8);
            SupportedEncodings.Add(Encoding.Unicode);
        }
        protected override bool CanWriteType(Type? type)
        {
            if (typeof(CoinDto).IsAssignableFrom(type) ||
                typeof(IEnumerable<CoinDto>).IsAssignableFrom(type))
            {
                return base.CanWriteType(type);
            }
            return false;
        }
        private static void FormatCsv(StringBuilder buffer, CoinDto coin)
        {
            buffer.AppendLine($"{coin.Id},{coin.Symbol},{coin.Price},{coin.Amount}");
        }

        public override async Task WriteResponseBodyAsync(OutputFormatterWriteContext context, Encoding selectedEncoding)
        {
            var response = context.HttpContext.Response;
            var buffer = new StringBuilder();

            if (context.Object is IEnumerable<CoinDto>)
            {
                foreach (var coin in (IEnumerable<CoinDto>)context.Object)
                    FormatCsv(buffer, coin);

            }
            else {
                FormatCsv(buffer, (CoinDto)context.Object);
            }
            await response.WriteAsync(buffer.ToString());
        }
    }
}
