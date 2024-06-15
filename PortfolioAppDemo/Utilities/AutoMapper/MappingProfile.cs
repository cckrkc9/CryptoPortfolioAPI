using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Models;

namespace PortfolioAppDemo.Utilities.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CoinDtoForUpdate, Coin>();
            CreateMap<Coin, CoinDto>();
            CreateMap<CoinDtoForInsertion, Coin>();
            CreateMap<UserForRegistrationDto, User>();
        }
    }
}
