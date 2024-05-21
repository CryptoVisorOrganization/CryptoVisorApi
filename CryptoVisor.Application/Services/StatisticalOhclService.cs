using CryptoVisor.Application.Interfaces;
using CryptoVisor.Core.Entities;
using CryptoVisor.Core.ValueObjects;
using System.Collections.Generic;
using System.Linq;

namespace CryptoVisor.Application.Services
{
    public class StatisticalOhclService
    {
        private readonly IOhlcRepository _ohlcRepository;

        public StatisticalOhclService(
            IOhlcRepository ohlcRepository
            )
        {
            _ohlcRepository = ohlcRepository;
        }

        public async Task<OhlcStatitical> GetOhlcStatitical(DateTime firstDate, DateTime lastDate, ECoinType coinType)
        {
            var coinHistories = await _ohlcRepository.GetDataFromPeriod(firstDate, lastDate, coinType);
            var coinHistoriesDaily = coinHistories.Where(x => x.Date.Hour == 0).ToList();

            var statitics = new OhlcStatitical
            {
                RelativeStrengthIndex = await GetRelativeStrengthIndexList(coinHistoriesDaily),
                BollingerBands = await GetBollingerBandsList(coinHistoriesDaily),
                ExponentialMovingAverageOf8days = await GetExponentialMovingAverageList(coinHistoriesDaily, 8),
                ExponentialMovingAverageOf14days = await GetExponentialMovingAverageList(coinHistoriesDaily, 14),
                ExponentialMovingAverageOf30days = await GetExponentialMovingAverageList(coinHistoriesDaily, 30),
                LastCloseValue = coinHistoriesDaily.OrderBy(x => x.Date).Select(x => x.Close).LastOrDefault()
            };

            return statitics;
        }

        private async Task<List<ExponentialMovingAverage>> GetExponentialMovingAverageList(IEnumerable<OhlcCoinHistory> coinHistories, int period)
        {
            var listOfEmaPeriods = new List<ExponentialMovingAverage>();

            var orderedCoinHistories = coinHistories.OrderByDescending(x => x.Date).ToList();

            for (int i = 0; i <= orderedCoinHistories.Count - period; i++)
            {
                var periodCoinList = orderedCoinHistories.Skip(i).Take(period).Select(x => x.Close).ToList();
                var ema = await GetExponentialMovingAverage(periodCoinList, period);

                var emaResult = new ExponentialMovingAverage
                {
                    Date = orderedCoinHistories.Skip(i).Select(x => x.Date).FirstOrDefault(),
                    Value = ema
                };

                listOfEmaPeriods.Add(emaResult);
            }

            return listOfEmaPeriods;
        }
        private async Task<double> GetExponentialMovingAverage(List<double> closes, int period)
        {
            double multiplier = 2.0 / (period + 1);
            double? previousEma = null;

            foreach (double close in closes)
            {
                double emaValue;
                if (previousEma == null)
                    emaValue = close;
                else
                    emaValue = (close - previousEma.Value) * multiplier + previousEma.Value;

                previousEma = emaValue;
            }

            return previousEma ?? 0;
        }

        private async Task<List<BollingerBands>> GetBollingerBandsList(IEnumerable<OhlcCoinHistory> coinHistories)
        {
            var listOfEmaPeriods = new List<BollingerBands>();

            var orderedCoinHistories = coinHistories.OrderByDescending(x => x.Date).ToList();

            for (int i = 0; i <= orderedCoinHistories.Count - 20; i++)
            {
                var periodCoinList = orderedCoinHistories.Skip(i).Take(20).Select(x => x.Close).ToList();
                var ema = await GetBollingerBands(periodCoinList);

                ema.Date = orderedCoinHistories.Skip(i).Select(x => x.Date).FirstOrDefault();

                listOfEmaPeriods.Add(ema);
            }

            return listOfEmaPeriods;
        }
        private async Task<BollingerBands> GetBollingerBands(List<double> closes)
        {
            int period = 20;
            int numStdDev = 2;

            double mean = closes.Average();
            double sumOfSquaresOfDifferences = closes.Select(val => (val - mean) * (val - mean)).Sum();
            double stdDev = Math.Sqrt(sumOfSquaresOfDifferences / period);

            double sma = mean;
            double upperBand = mean + (numStdDev * stdDev);
            double lowerBand = mean - (numStdDev * stdDev);

            return new BollingerBands
            {
                Higher = upperBand,
                Lower = lowerBand,
                Base = sma
            };
        }

        private async Task<List<RelativeStrengthIndex>> GetRelativeStrengthIndexList(IEnumerable<OhlcCoinHistory> coinHistories)
        {
            var listOfRsiPeriods = new List<RelativeStrengthIndex>();

            var orderedCoinHistories = coinHistories.OrderByDescending(x => x.Date).ToList();

            for (int i = 0; i <= orderedCoinHistories.Count - 14; i++)
            {
                var periodCoinList = orderedCoinHistories.Skip(i).Take(14).Select(x => x.Close).ToList();
                var rsi = await GetRelativeStrengthIndex(periodCoinList);

                var rsiResult = new RelativeStrengthIndex
                {
                    Date = orderedCoinHistories.Skip(i).Select(x => x.Date).FirstOrDefault(),
                    Value = rsi
                };

                listOfRsiPeriods.Add(rsiResult);
            }

            return listOfRsiPeriods;
        }
        private async Task<double> GetRelativeStrengthIndex(List<double> closes)
        {
            var period = closes.Count();

            List<double> diaryVariation = new List<double>();
            for (int i = 1; i < closes.Count; i++)
            {
                diaryVariation.Add(closes.Skip(i).FirstOrDefault() - closes.Skip(i - 1).FirstOrDefault());
            }

            List<double> gains = [];
            List<double> losses = [];
            foreach (var change in diaryVariation)
            {
                gains.Add(Math.Max(0, change));
                losses.Add(Math.Max(0, -change));
            }

            double avgGain = gains.GetRange(0, period - 1).Sum() / period;
            double avgLoss = losses.GetRange(0, period - 1).Sum() / period;

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
