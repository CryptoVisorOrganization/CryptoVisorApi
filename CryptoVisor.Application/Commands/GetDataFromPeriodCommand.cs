using CryptoVisor.Core.Entities;

namespace CryptoVisor.Application.Commands
{
	public class GetDataFromPeriodCommand
	{
		public DateTime FirstDate { get; set; }
		public DateTime LastDate { get; set; }
		public ECoinType ECoinType { get; set; }
	}
}
