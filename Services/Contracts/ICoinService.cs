using Entities.DataTransferObjects;
using Entities.RequestFeatures;
using System.Dynamic;

namespace Services.Contracts
{
    public interface ICoinService
    {
        Task<(IEnumerable<ExpandoObject> coins, MetaData metaData)> GetAllCoinsAsync(CoinParameters coinParameters, bool trackChanges);
        Task<CoinDto> GetOneCoinByIdAsync(int id, bool trackChanges);
        Task<CoinDto> CreateOneCoinAsync(CoinDtoForInsertion coin);
        Task UpdateOneCoinAsync(int id, CoinDtoForUpdate coinDto, bool trackChanges);
        Task DeleteOneCoinAsync(int id, bool trackChanges);
    }
}
