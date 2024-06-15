namespace Entities.RequestFeatures
{
    public class CoinParameters : RequestParameters
	{
        public double MinMarketCap { get; set; }
        public double MaxMarketCap { get; set; }
        public bool ValidPriceRange => MinMarketCap < MaxMarketCap;
        public String? SearchTerm { get; set; }
        public CoinParameters()
        {
            OrderBy = "id";
            MaxMarketCap = 9_999_999_999_999;
            PageSize = 10;
            PageNumber = 1;
        }
    }
}
