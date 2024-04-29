using CryptoVisor.Core.Common;

namespace CryptoVisor.Core.Entities
{
	public class OhclCoinHistory : Entity
	{
		public ECoinType CoinType {  get; set; }

		public DateTime Date {  get; set; }

		public int Open {  get; set; }

		public int High { get; set; }

		public int Low { get; set; }

		public int Close { get; set; }
	}
}
