using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Exceptions;
using Entities.Models;
using Entities.RequestFeatures;
using Repositories.Contracts;
using Services.Contracts;
using System.Dynamic;

namespace Services
{
    public class CoinManager : ICoinService
    {
        private readonly IRepositoryManager _manager;
        private readonly ILoggerService _logger;
        private readonly IMapper _mapper;
        private readonly IDataShaper<CoinDto> _shaper;

        private async Task<Coin> GetOneCoinByIdAndCheckExists(int id, bool trackChanges)
        {
            var entitiy = await _manager.Coin.GetOneCoinByIdAsync(id, trackChanges);

            if (entitiy is null)
                throw new CoinNotFoundException(id);
            return entitiy;
        }
        public CoinManager(IRepositoryManager manager, ILoggerService logger, IMapper mapper, IDataShaper<CoinDto> shaper)
        {
            _manager = manager;
            _logger = logger;
            _mapper = mapper;
            _shaper = shaper;
        }

        public async Task<CoinDto> CreateOneCoinAsync(CoinDtoForInsertion coinDto)
        {
            var entity = _mapper.Map<Coin>(coinDto);
            _manager.Coin.CreateOneCoin(entity);
            await _manager.SaveAsync();
            return _mapper.Map<CoinDto>(entity);
        }
        public async Task DeleteOneCoinAsync(int id, bool trackChanges)
        {
            var entitiy = await GetOneCoinByIdAndCheckExists(id, trackChanges);
            _manager.Coin.DeleteOneCoin(entitiy);
            await _manager.SaveAsync();
        }
        public async Task<(IEnumerable<ExpandoObject> coins, MetaData metaData)> GetAllCoinsAsync(CoinParameters coinParameters, bool trackChanges)
        {
            var coinsWithMetaData = await _manager.Coin.GetAllCoinsAsync(coinParameters, trackChanges);
            var coinDto = _mapper.Map<IEnumerable<CoinDto>>(coinsWithMetaData);

            var shapedData = _shaper.ShapeData(coinDto, coinParameters.Fields);

            return (coins : shapedData, metaData: coinsWithMetaData.MetaData);
        }

        public async Task<CoinDto> GetOneCoinByIdAsync(int id, bool trackChanges)
        {

            var entitiy = await GetOneCoinByIdAndCheckExists(id, trackChanges);
            return _mapper.Map<CoinDto>(entitiy);
        }

        public async Task UpdateOneCoinAsync(int id, CoinDtoForUpdate coinDto, bool trackChanges)
        {
            var entitiy = await GetOneCoinByIdAndCheckExists(id, trackChanges);
             entitiy = _mapper.Map<Coin>(coinDto);

            _manager.Coin.Update(entitiy);
            await _manager.SaveAsync();
        }
    }
}
