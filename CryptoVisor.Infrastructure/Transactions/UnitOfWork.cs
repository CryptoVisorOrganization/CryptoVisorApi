using Microsoft.EntityFrameworkCore;
using CryptoVisor.Application.Interfaces;
using CryptoVisor.Infrastructure.Contexts;

namespace CryptoVisor.Infrastructure.Transactions
{
	public class UnitOfWork(CryptoVisorContext context) : IUnitOfWork, IDisposable
	{
		private readonly CryptoVisorContext _context = context;
		private bool _disposed = false;

		public void Dispose()
		{
			if (!_disposed)
				_context.Dispose();

			_disposed = true;
		}

		public async Task CommitAsync()
		{
			await _context.SaveChangesAsync();
		}

		public async Task Rollback()
		{
			foreach (var entry in _context.ChangeTracker.Entries())
			{
				switch (entry.State)
				{
					case EntityState.Added:
						entry.State = EntityState.Detached;
						break;

					case EntityState.Modified:
					case EntityState.Deleted:
						await entry.ReloadAsync();
						break;
				}
			}
		}
	}
}
