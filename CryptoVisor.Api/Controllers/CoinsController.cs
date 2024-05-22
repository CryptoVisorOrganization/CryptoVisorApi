using CryptoVisor.Application.Commands;
using CryptoVisor.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CryptoVisor.Api.Controllers
{
    [ApiController]
    [Route("[controller]"), Authorize]
    public class CoinsController : ControllerBase
    {
        [HttpGet]
        public async Task<CommandResponse> GetAllCoins(
            [FromServices] CoinsService coinsService
            )
        {
            var returnObject = await coinsService.GetCoinInfos();

            return new CommandResponse(
                "Dados obtidos com sucesso!",
                false,
                returnObject
                );
        }
    }
}
