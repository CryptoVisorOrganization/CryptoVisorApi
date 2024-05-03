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

        public async Task<CommandResponse> GetListFromApiAndSaveOnDB(SeedDatabaseCommand command)
        {
            var newCoinHistories = await _cryptoGetterApi.GetOhclValuesList(command.Period, command.ECoinType);

            var orderedList = newCoinHistories.Select(x => x.Date).OrderBy(x => x.Date).AsEnumerable();

            var firstDate = orderedList.FirstOrDefault();
            var lastDate = orderedList.LastOrDefault();

            var existentCoinHistories = await _ohlcRepository.GetDataFromPeriod(firstDate, lastDate, command.ECoinType);

            foreach (var coin in newCoinHistories)
            {
                var canAddNewRow = existentCoinHistories.Where(x => x.Date == coin.Date
                                                                && x.CoinType == command.ECoinType)
                                                                .Any();
                if (!canAddNewRow)
                    await _ohlcRepository.SaveRowAsync(coin);
            }

            await _unitOfWork.CommitAsync();

            return new CommandResponse($"Dados salvos no Banco de dados", false, newCoinHistories);
        }
    }
}
