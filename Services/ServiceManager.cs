using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Repositories.Contracts;
using Services.Contracts;

namespace Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<ICoinService> _coinService;
        private readonly Lazy<IAuthenticationService> _authenticationService;
        public ServiceManager(IRepositoryManager repositoryManager, ILoggerService logger, IMapper mapper, 
            IDataShaper<CoinDto> shaper,UserManager<User> userManager, IConfiguration configuration)
        {
            _coinService = new Lazy<ICoinService>(() => 
                new CoinManager(repositoryManager, logger, mapper, shaper));

            _authenticationService = new Lazy<IAuthenticationService>(() =>
                new AuthenticationManager(logger, mapper, userManager, configuration));
        }
        public ICoinService CoinService => _coinService.Value;
        public IAuthenticationService AuthenticationService => _authenticationService.Value;

    }
}
