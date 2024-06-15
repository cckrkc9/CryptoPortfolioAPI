
using System.ComponentModel.DataAnnotations;

namespace Entities.DataTransferObjects
{
    public record CoinDtoForUpdate : CoinDtoForManupilation
    {
        [Required]
        public int Id { get; init; }
    }
    
}
