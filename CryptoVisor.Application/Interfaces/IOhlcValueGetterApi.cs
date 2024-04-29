using CryptoVisor.Core.Entities;

namespace CryptoVisor.Application.Interfaces
{
	public interface ICryptoGetterApi
	{
		Task<IEnumerable<OhclCoinHistory>> GetOhclValuesList(int period);
	}
}
