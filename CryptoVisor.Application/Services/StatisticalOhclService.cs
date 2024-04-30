using CryptoVisor.Application.Commands;
using CryptoVisor.Application.Interfaces;
using CryptoVisor.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CryptoVisor.Application.Services
{
	public class StatisticalOhclService
	{
		private readonly IOhlcRepository _ohlcRepository;
		private readonly IUnitOfWork _unitOfWork;

		public StatisticalOhclService(
			IOhlcRepository ohlcRepository,
			IUnitOfWork unitOfWork

			)
		{
			_ohlcRepository = ohlcRepository;
			_unitOfWork = unitOfWork;
		}

		public async Task<OhlcStatitical> GetOhlcStatitical( DateTime firstDate, DateTime lastDate, ECoinType coinType) 
		{
			var coinHistories = await _ohlcRepository.GetDataFromPeriod( firstDate, lastDate, coinType );

			

			return new OhlcStatitical();
		}

		private async Task GetExponentialMovingAverage(IEnumerable<OhlcCoinHistory> coinHistories)
		{
			var daysPeriod = coinHistories.Count();
			var initialMME = coinHistories.Average(x => x.Close);
			var multiplicator = 2 / (daysPeriod + 1);

		}

		private async Task<double> GetBollingerBands()
		{
			return 0.0;
		}

		private async Task<double> GetRelativeStrengthIndex(IEnumerable<OhlcCoinHistory> coinHistories)
		{
			List<double> closes = coinHistories.Select(x => x.Close).ToList();
			var period = coinHistories.Count();

			List<double> diaryVariation = new List<double>();
			for (int i = 1; i < closes.Count; i++)
			{
				diaryVariation.Add(closes[i] - closes[i - 1]);
			}

			List<double> gains = [];
			List<double> losses = [];
			foreach (var change in diaryVariation)
			{
				gains.Add(Math.Max(0, change));
				losses.Add(Math.Max(0, -change));
			}

			double avgGain = gains.GetRange(0, period).Sum() / period;
			double avgLoss = losses.GetRange(0, period).Sum() / period;

			for (int i = period; i < gains.Count; i++)
			{
				avgGain = ((avgGain * (period - 1)) + gains[i]) / period;
				avgLoss = ((avgLoss * (period - 1)) + losses[i]) / period;
			}

			double rs = avgGain / avgLoss;
			double rsi = 100 - (100 / (1 + rs));
			return rsi;
		}
	}
}
