using Entities.Models;
using Entities.RequestFeatures;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using Repositories.EFCore.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EFCore
{
    public sealed class CoinRepository : RepositoryBase<Coin>, ICoinRepository
    {
        public CoinRepository(RepositoryContext context) : base(context)
        {
        }

        public void CreateOneCoin(Coin coin) => Create(coin);

        public void DeleteOneCoin(Coin coin) => Delete(coin);

        public async Task<PagedList<Coin>> GetAllCoinsAsync(CoinParameters coinParameters, bool trackChanges)
        {
            var coins = await FindAll(trackChanges)
                .FilterCoins(coinParameters.MinMarketCap, coinParameters.MaxMarketCap)
                .Search(coinParameters.SearchTerm)
                .Sort(coinParameters.OrderBy)
                .ToListAsync();

            return PagedList<Coin>
                .ToPagedList(coins, coinParameters.PageNumber, coinParameters.PageSize);
        } 

        public async Task<Coin> GetOneCoinByIdAsync(int id, bool trackChanges) => 
            await FindByCondition(b => b.Id.Equals(id), trackChanges).
            SingleOrDefaultAsync();

        public void UpdateOneCoin(Coin coin) => Update(coin);
    }
}
