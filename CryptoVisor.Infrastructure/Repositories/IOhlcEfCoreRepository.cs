using CryptoVisor.Application.Interfaces;
using CryptoVisor.Core.Entities;
using CryptoVisor.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
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

		public async Task SaveListAsync(IEnumerable<OhlcCoinHistory> dataList) => await _cryptoVisorContext.OhclCoinHistory.AddRangeAsync(dataList);

		public async Task<bool> VerifyIfExistsCoinOnPeriod(DateTime firstDate, DateTime lastDate, ECoinType eCoinType) => await _cryptoVisorContext.OhclCoinHistory
			.Where(x => x.Date >= firstDate 
					&& x.Date <= lastDate 
					&& x.CoinType == eCoinType).AnyAsync();

		public async Task TruncateTable() => await _cryptoVisorContext.Database.ExecuteSqlRawAsync("TRUNCATE TABLE [OhclCoinHistory]");

		public async Task<IEnumerable<OhlcCoinHistory>> GetDataFromPeriod(DateTime firstDate, DateTime lastDate, ECoinType eCoinType) => await _cryptoVisorContext.OhclCoinHistory
			.Where(x => x.Date >= firstDate
					&& x.Date <= lastDate
					&& x.CoinType == eCoinType).ToListAsync();
	}
}
