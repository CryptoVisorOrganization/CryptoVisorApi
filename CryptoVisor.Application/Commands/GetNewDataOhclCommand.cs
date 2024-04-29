using CryptoVisor.Core.Entities;

namespace CryptoVisor.Application.Commands
{
	public class GetNewDataOhclCommand
	{
		public int Period { get; set; }
		public ECoinType ECoinType { get; set; }
		public bool ReCreateTable { get; set; } = false;
	}
}
