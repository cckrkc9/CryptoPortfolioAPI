using Repositories.Contracts;

namespace Repositories.EFCore
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _context;
        private readonly Lazy<CoinRepository> _coinRepository;
        public RepositoryManager(RepositoryContext context)
        {
            _context = context;
            _coinRepository = new Lazy<CoinRepository>(() => new CoinRepository(_context));
        }
        public ICoinRepository Coin => _coinRepository.Value;

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
