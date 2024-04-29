using CryptoVisor.Core.Common;

namespace CryptoVisor.Core.Entities
{
	public class OhclCoinHistory : Entity
	{
		public ECoinType CoinType { get; set; } = ECoinType.NotRegistered;

		public DateTime Date {  get; set; }

		public double Open {  get; set; }

		public double High { get; set; }

		public double Low { get; set; }

		public double Close { get; set; }
	}
}
