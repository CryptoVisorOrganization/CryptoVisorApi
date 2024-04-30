using CryptoVisor.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace CryptoVisor.Infrastructure.Contexts
{
	public class CryptoVisorContext : DbContext
	{
		public CryptoVisorContext(DbContextOptions<CryptoVisorContext> options) : base(options)
		{
		}

		public DbSet<OhlcCoinHistory> OhclCoinHistory { get; set; }
	}
}
