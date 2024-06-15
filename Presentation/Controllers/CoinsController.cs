using Entities.DataTransferObjects;
using Entities.Exceptions;
using Entities.Models;
using Entities.RequestFeatures;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presentation.ActionFilters;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    [ServiceFilter(typeof(LogFilterAttribute))]
    [ApiController]
    [Route("api/coin")]
    public class CoinsController : ControllerBase
    {
        private readonly IServiceManager _manager;
        public CoinsController(IServiceManager manager)
        {
            _manager = manager;
        }

        [Authorize(Roles = "User")]
        [HttpGet]
        public async Task<IActionResult> GetAllCoinsAsync([FromQuery] CoinParameters coinParameters)
        {
            var pagedResult = await _manager
                .CoinService
                .GetAllCoinsAsync(coinParameters, false);

            Response.Headers.Add("X-Pagination", 
                JsonSerializer.Serialize(pagedResult.metaData));

            return Ok(pagedResult.coins);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetoneCoinAsync([FromRoute(Name = "id")] int id)
        {
            var coin = await _manager.CoinService.GetOneCoinByIdAsync(id, false);

            return Ok(coin);
        }

        [Authorize(Roles = "Admin")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [HttpPost]
        public async Task<IActionResult> CreateOneCoinAsync([FromBody] CoinDtoForInsertion coinDto)
        {
            var coin = await _manager.CoinService.CreateOneCoinAsync(coinDto);

            return StatusCode(201, coin);
        }

        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateOneCoinAsync([FromRoute(Name = "id")] int id, [FromBody] CoinDtoForUpdate coinDto)
        {
            await _manager.CoinService.UpdateOneCoinAsync(id, coinDto, false);
            return NoContent();
        }
        
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteOneCoinasync([FromRoute(Name = "id")] int id)
        {
            await _manager.CoinService.DeleteOneCoinAsync(id, false);
            return NoContent();

        } 
    }
}
