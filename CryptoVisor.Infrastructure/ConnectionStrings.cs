using Microsoft.Extensions.Configuration;
using System.IO;

namespace CryptoVisor.Infrastructure
{
	public class ConnectionStrings
	{
		public IConfiguration Configuration { get; }
		public ConnectionStrings()
		{
			IConfigurationBuilder builder = new ConfigurationBuilder();
			builder.AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json"));
			Configuration = builder.Build();
		}

		public ConnectionStrings(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public string CoinGeckoUrlApi
		{
			get
			{
				var conn = Configuration.GetConnectionString("CoinGeckoUrlApi");
				return conn ?? String.Empty;
			}
		}

		public string CoinGeckoCredentials
		{
			get
			{
				var conn = Configuration.GetConnectionString("CoinGeckoCredentials");
				return conn ?? String.Empty;
			}
		}

        public string UserApi
        {
            get
            {
                var conn = Configuration.GetConnectionString("UserApi");
                return conn ?? String.Empty;
            }
        }

        public string PasswordApi
        {
            get
            {
                var conn = Configuration.GetConnectionString("PasswordApi");
                return conn ?? String.Empty;
            }
        }
    }
}

