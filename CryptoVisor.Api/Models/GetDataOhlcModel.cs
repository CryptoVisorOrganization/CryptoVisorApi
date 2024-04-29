using CryptoVisor.Core.Entities;

namespace CryptoVisor.Api.Models
{
	internal class GetDataOhlcModel
	{
		public DateTime FirstDate { get; set; }
		public DateTime LastDate { get; set; }
		public ECoinType ECoinType { get; set; }
		public bool ReCreateTable { get; set; } = false;
	}
}
