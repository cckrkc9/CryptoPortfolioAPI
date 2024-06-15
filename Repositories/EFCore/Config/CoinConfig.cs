using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Repositories.EFCore.Config
{
    public class CoinConfig : IEntityTypeConfiguration<Coin>
    {
        public void Configure(EntityTypeBuilder<Coin> builder)
        {
            builder.HasData(
                new Coin { Id = 1, Symbol = "BTC", Price = 63000, Amount = 1, MarketCap = 1_370_000_000_000, Chain = "Bitcoin"},
                new Coin { Id = 2, Symbol = "ETH", Price = 3100, Amount = 1, MarketCap = 444_000_000_000, Chain = "Ethereum" },
                new Coin { Id = 3, Symbol = "AVAX", Price = 35, Amount = 10, MarketCap = 12_810_000_000, Chain = "Avalanche" }
            );
        }
    }
}
