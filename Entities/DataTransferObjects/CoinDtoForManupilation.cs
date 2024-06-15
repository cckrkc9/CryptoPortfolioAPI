
using System.ComponentModel.DataAnnotations;

namespace Entities.DataTransferObjects
{
    public abstract record CoinDtoForManupilation
    {
        [Required]
        [MinLength(2)]//Constraint to limit the minimum length of the field to 2 characters(A usage example for an attribute).
        [MaxLength(20)]//Constraint to limit the maximum length of the field to 20 characters(A usage example for an attribute).
        public string Symbol { get; init; }
        [Required]
        public double Price { get; init; }
        [Required]
        public double Amount { get; init; }
        [Required]
        public double MarketCap { get; init; }
        [Required]
        public string Chain { get; init; }
    }
}
