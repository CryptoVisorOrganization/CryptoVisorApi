using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoVisor.Core.Entities
{
    public enum ECoinType
    {
        NotRegistered,

        [Display(Name = "bitcoin")]
        Bitcoin,

        [Display(Name = "ethereum")]
        Ethereum,

        [Display(Name = "binancecoin")]
        BNB,

        [Display(Name = "solana")]
        Solana,

        [Display(Name = "ripple")]
        XRP,

        [Display(Name = "dogecoin")]
        Dogecoin,

        [Display(Name = "the-open-network")]
        Toncoin,

        [Display(Name = "cardano")]
        Cardano,

        [Display(Name = "shiba-inu")]
        ShibaInu,

        [Display(Name = "avalanche-2")]
        Avalanche,

        [Display(Name = "tron")]
        TRON,

        [Display(Name = "polkadot")]
        Polkadot,

        [Display(Name = "bitcoin-cash")]
        BitcoinCash,

        [Display(Name = "chainlink")]
        Chainlink,

        [Display(Name = "matic-network")]
        Polygon,

        [Display(Name = "near")]
        NEARProtocol,  

        [Display(Name = "internet-computer")]
        InternetComputer,

        [Display(Name = "litecoin")]
        Litecoin,

        [Display(Name = "uniswap")]
        Uniswap,

        [Display(Name = "aptos")]
        Aptos
    }
}
