using CryptoVisor.Core.Entities;
using Newtonsoft.Json.Converters;
using System.Text.Json.Serialization;

namespace CryptoVisor.Application.Commands
{
    public class SeedDatabaseCommand
	{
		public int Period { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public ECoinType ECoinType { get; set; }
	}
}
