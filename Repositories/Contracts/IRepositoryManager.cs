
namespace Repositories.Contracts
{
    public interface IRepositoryManager
    {
        ICoinRepository Coin { get; }
        Task SaveAsync();
    }
}
