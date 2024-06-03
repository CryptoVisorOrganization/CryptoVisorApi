using CryptoVisor.Application.Extensions;
using CryptoVisor.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoVisor.Application.Services
{
    public class CoinsService
    {
        public async Task<IEnumerable<CoinInfo>> GetCoinInfos()
        {
            var coinInfos = new List<CoinInfo>();

            var rootPath = AppDomain.CurrentDomain.BaseDirectory;

            foreach (var coin in Enum.GetValues(typeof(ECoinType)).Cast<ECoinType>())
            {
                string displayName = coin.GetDisplayName();

                if (displayName != String.Empty)
                {
                    var imagePath = Path.Combine(rootPath, "CoinsImages", $"{displayName}.png");

                    if (File.Exists(imagePath))
                    {
                        var imageBytes = File.ReadAllBytes(imagePath);
                        var base64Image = Convert.ToBase64String(imageBytes);

                        coinInfos.Add(new CoinInfo
                        {
                            Name = coin.ToString(),
                            Base64Image = base64Image
                        });
                    }
                }
            }

            return coinInfos;
        }
    }
}
