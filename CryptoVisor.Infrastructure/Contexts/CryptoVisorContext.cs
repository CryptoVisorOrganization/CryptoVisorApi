using CryptoVisor.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace CryptoVisor.Infrastructure.Contexts
{
	public class CryptoVisorContext(DbContextOptions<CryptoVisorContext> options) : DbContext(options)
	{
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
		}

		public DbSet<OhclCoinHistory> OhclCoinHistory { get; set; }
	}
}
