using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using CryptoVisor.Infrastructure.Contexts;
using CryptoVisor.Application.Interfaces;
using CryptoVisor.Application.Services;
using CryptoVisor.Infrastructure.Transactions;
using CryptoVisor.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using CryptoVisor.Infrastructure.Adapters;

namespace CryptoVisor.Infrastructure
{
	public static class InfrastructureConfiguration
	{
		public static void ConfigurePersistenceApp(this IServiceCollection services, IConfiguration configuration, ServiceLifetime serviceLifetime = ServiceLifetime.Scoped)
		{
			//services.AddLogging();

			AddContexts(services, configuration, serviceLifetime);
			AddRepositories(services, serviceLifetime);
			AddServices(services);

			services.TryAddSingleton<ConnectionStrings>();
		}

		private static void AddContexts(IServiceCollection services, IConfiguration configuration, ServiceLifetime serviceLifetime = ServiceLifetime.Scoped)
		{
			var connectionString = configuration.GetConnectionString("MainConnection") ?? throw new InvalidOperationException("Connection string 'MainConnection' not found.");
			services.AddDbContext<CryptoVisorContext>(opt => opt.UseSqlite(connectionString), serviceLifetime);
		}

		private static void AddServices(IServiceCollection services)
		{
			services.TryAddTransient<OhlcService>();
			services.TryAddTransient<StatisticalOhclService>();
        }

		private static void AddRepositories(IServiceCollection services, ServiceLifetime serviceLifetime = ServiceLifetime.Scoped)
		{
			services.AddDynamic<IUnitOfWork, UnitOfWork>(serviceLifetime);
			services.AddDynamic<IOhlcRepository, IOhlcEfCoreRepository>(serviceLifetime);
			services.AddDynamic<ICryptoGetterApi, CoinGeckoApi>(serviceLifetime);

		}


		private static void AddDynamic<TInterface, TClass>(this IServiceCollection services, ServiceLifetime lifetime = ServiceLifetime.Singleton)
		where TClass : class, TInterface
		where TInterface : class
		{
			services.Add(new ServiceDescriptor(typeof(TInterface), typeof(TClass), lifetime));
		}

	}
}
