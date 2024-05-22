using CryptoVisor.Core.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoVisor.Core.Entities
{
	public class OhlcStatitical
	{
		public double LastCloseValue { get; set; }
		public List<RelativeStrengthIndex> RelativeStrengthIndex { get; set; } //ok
		public List<ExponentialMovingAverage> ExponentialMovingAverageOf8days { get; set;}
		public List<ExponentialMovingAverage> ExponentialMovingAverageOf14days { get; set; }
		public List<ExponentialMovingAverage> ExponentialMovingAverageOf30days { get; set; }
		public List<BollingerBands> BollingerBands { get; set; }
    }
}
