

namespace Services.Contracts
{
    public interface IServiceManager
    {
        ICoinService CoinService { get; }
        IAuthenticationService AuthenticationService { get; }
    }
}
