using Entities.Models;
using System.Linq.Dynamic.Core;

namespace Repositories.EFCore.Extensions
{
    public static class CoinRepositoryExtensions
    {
        public static IQueryable<Coin> FilterCoins(this IQueryable<Coin> coins,
            double minMarketCap, double maxMarketCap) =>
            coins.Where(coin =>
            coin.MarketCap >= minMarketCap &&
            coin.MarketCap <= maxMarketCap);
        public static IQueryable<Coin> Search(this IQueryable<Coin> coins,
            string searchTerm )
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return coins;

            var lowerCaseTerm = searchTerm.Trim().ToLower();
            return coins
                .Where(c => c.Symbol
                .ToLower()
                .Contains(searchTerm));
        }

        public static IQueryable<Coin> Sort(this IQueryable<Coin> coins, string orderByQueryString)
        {
            if(string.IsNullOrWhiteSpace(orderByQueryString))
                return coins.OrderBy(c => c.Id);

            var orderQuery = OrderQueryBuilder.CreateOrderQuery<Coin>(orderByQueryString);

            if (orderQuery is null)
                return coins.OrderBy(c => c.Id);

            return coins.OrderBy(orderQuery);
        }
    }
}
