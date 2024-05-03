using CryptoVisor.Core.Entities;

namespace CryptoVisor.Application.Interfaces
{
	public interface ICryptoGetterApi
	{
		Task<IEnumerable<OhlcCoinHistory>> GetOhclValuesList(int period, ECoinType eCoinType);
	}
}
