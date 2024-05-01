using CryptoVisor.Api.Models;
using CryptoVisor.Application.Commands;
using CryptoVisor.Application.Interfaces;
using CryptoVisor.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace CryptoVisor.Api.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class OhlcHistoryController : ControllerBase
	{
		[HttpGet("GetNewDataOhcl")]
		public async Task<CommandResponse> GetNewDataOhcl(
			[FromServices] OhlcService ohlcService,
			[FromQuery] GetNewDataOhclCommand command)
		{
			return await ohlcService.GetListFromApiAndSaveOnDB(command);
		}

        [HttpGet("testes")]
        public async Task<CommandResponse> GetData(
            [FromServices] StatisticalOhclService statisticalOhclService,
            [FromQuery] GetDataFromPeriodCommand command
            )
        {
            await statisticalOhclService.GetOhlcStatitical(command.FirstDate, command.LastDate, command.ECoinType);

            return new CommandResponse(
                "Dados obtidos com sucesso!",
                false,
                null
                );
        }

        [HttpGet("GetData")]
		public async Task<CommandResponse> GetData(
			[FromServices] IOhlcRepository ohlcRepository,
			[FromQuery] GetDataFromPeriodCommand command
			)
		{
			try
			{
				return new CommandResponse(
				"Dados obtidos com sucesso!",
				false,
				await ohlcRepository.GetDataFromPeriod(command.FirstDate, command.LastDate, command.ECoinType)
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
