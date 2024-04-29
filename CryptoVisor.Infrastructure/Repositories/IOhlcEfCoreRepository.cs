using CryptoVisor.Application.Interfaces;
using CryptoVisor.Core.Entities;
using CryptoVisor.Infrastructure.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoVisor.Infrastructure.Repositories
{
	internal class IOhlcEfCoreRepository : IOhlcRepository
	{
		private readonly CryptoVisorContext _cryptoVisorContext;

		public IOhlcEfCoreRepository(CryptoVisorContext cryptoVisorContext)
		{
			_cryptoVisorContext = cryptoVisorContext;
		}

		public async Task SaveListAsync(List<OhclCoinHistory> dataList) => await _cryptoVisorContext.OhclCoinHistory.AddRangeAsync(dataList);
	}
}
