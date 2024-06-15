using Entities.Models;
using Entities.RequestFeatures;

namespace Repositories.Contracts
{
    public interface ICoinRepository : IRepositoryBase<Coin>
    {
        Task<PagedList<Coin>> GetAllCoinsAsync(CoinParameters coinParameters, bool trackChanges);
        Task<Coin> GetOneCoinByIdAsync(int id, bool trackChanges);
        void CreateOneCoin(Coin coin);
        void UpdateOneCoin(Coin coin);
        void DeleteOneCoin(Coin coin);
    }
}
