using CryptoVisor.Application.Interfaces;
using CryptoVisor.Core.Entities;

namespace CryptoVisor.Infrastructure.Adapters
{
	internal class CoinGeckoApi : ICryptoGetterApi
	{
		public async Task<List<OhclCoinHistory>> GetOhclValuesList()
		{
			return new List<OhclCoinHistory>();
		}
	}
}
