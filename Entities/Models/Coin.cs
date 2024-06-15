
namespace Entities.Models
{
    public class Coin
    {
        public int Id { get; set; }
        public string Symbol { get; set; }
        public double Price { get; set; }
        public double Amount { get; set; }
        public double MarketCap { get; set; }
        public string Chain { get; set; }
    }
}
