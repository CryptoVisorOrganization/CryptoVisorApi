using CryptoVisor.Application.Commands;
using CryptoVisor.Application.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CryptoVisor.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OhlcStatisticsController : ControllerBase
    {
        [HttpGet]
        public async Task<CommandResponse> Index(
            [FromServices] StatisticalOhclService statisticalOhclService,
            [FromQuery] GetDataFromPeriodCommand command
            )
        {
            var returnObject = await statisticalOhclService.GetOhlcStatitical(command.FirstDate, command.LastDate, command.ECoinType);
            //JsonConvert.SerializeObject(returnObject, Formatting.Indented);
            return new CommandResponse(
                "Dados obtidos com sucesso!",
                false,
                returnObject
                );
        }
    }
}
