using CryptoVisor.Application.Commands;
using CryptoVisor.Application.Interfaces;
using CryptoVisor.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CryptoVisor.Api.Controllers
{
    [ApiController]
	[Route("[controller]"), Authorize]
    public class OhlcHistoryController : ControllerBase
	{
		[HttpGet("SeedDatabase")]
		public async Task<CommandResponse> GetNewDataOhcl(
			[FromServices] OhlcService ohlcService,
			[FromQuery] SeedDatabaseCommand command)
		{
			return await ohlcService.GetListFromApiAndSaveOnDB(command);
		}

        [HttpGet("GetData")]
		public async Task<CommandResponse> GetData(
			[FromServices] IOhlcRepository ohlcRepository,
			[FromQuery] GetDataFromPeriodCommand command
			)
		{
			var coinHistories = await ohlcRepository.GetDataFromPeriod(command.FirstDate, command.LastDate, command.ECoinType);

            try
            {
				return new CommandResponse(
				"Dados obtidos com sucesso!",
				false,
                coinHistories.Where(x => x.Date.Hour == 0).ToList()
				);
			}
			catch
			{
				return new CommandResponse(
				"Houve um erro ao obter os dados!",
				true,
				null
				);
			}

		}
	}
}
