using CryptoVisor.Application.Commands;
using CryptoVisor.Application.Interfaces;

namespace CryptoVisor.Application.Services
{
	public class OhlcService
	{
		private readonly ICryptoGetterApi _cryptoGetterApi;
		private readonly IOhlcRepository _ohlcRepository;
		private readonly IUnitOfWork _unitOfWork;

		public OhlcService(
			ICryptoGetterApi cryptoGetterApi,
			IOhlcRepository ohlcRepository,
			IUnitOfWork unitOfWork

			)
		{
			_cryptoGetterApi = cryptoGetterApi;
			_ohlcRepository = ohlcRepository;
			_unitOfWork = unitOfWork;
		}

		public async Task<CommandResponse> GetListFromApiAndSaveOnDB(GetNewDataOhclCommand command)
		{
			var data = await _cryptoGetterApi.GetOhclValuesList(command.Period);

			if (command.ReCreateTable)
				await _ohlcRepository.TruncateTable();

			var orderedList = data.Select(x => x.Date).OrderBy(x => x.Date).AsEnumerable();

			var firstDate = orderedList.FirstOrDefault();
			var lastDate = orderedList.LastOrDefault();
			var coinType = data.Select(x => x.CoinType).FirstOrDefault();

			var canSaveHistoryOnDB = await _ohlcRepository.VerifyIfExistsCoinOnPeriod(firstDate, lastDate, coinType);

			if (!canSaveHistoryOnDB)
			{
				await _ohlcRepository.SaveListAsync(data);
				await _unitOfWork.CommitAsync();

				return new CommandResponse($"Dados salvos no Banco de dados", false, data);
			}
			else
				return new CommandResponse($"Já há registros salvos no periodo de {firstDate} à {lastDate} e com o tipo de moeda: {coinType}", true, null);
		}
	}
}
