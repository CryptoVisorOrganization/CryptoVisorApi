using CryptoVisor.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

		public async Task GetListFromApiAndSaveOnDB()
		{
			var data = await _cryptoGetterApi.GetOhclValuesList();
			await _ohlcRepository.SaveListAsync( data );

			await _unitOfWork.CommitAsync();
		}
	}
}
