namespace Entities.Exceptions
{
    public sealed class CoinNotFoundException : NotFoundException {
        public CoinNotFoundException(int id) : base($"The coin with id :{id} could not found")
        {
            
        }
    }
}
