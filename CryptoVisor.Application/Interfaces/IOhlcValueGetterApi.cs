using CryptoVisor.Core.Entities;

namespace CryptoVisor.Application.Interfaces
{
	public interface ICryptoGetterApi
	{
		Task<List<OhclCoinHistory>> GetOhclValuesList();
	}
}
