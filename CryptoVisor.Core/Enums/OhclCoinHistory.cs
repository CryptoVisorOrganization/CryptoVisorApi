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
        Bitcoin, // c

        [Display(Name = "ethereum")]
        Ethereum, // c

        [Display(Name = "binancecoin")]
        BNB, // c

        [Display(Name = "solana")]
        Solana, // c

        [Display(Name = "ripple")]
        XRP, // c

        [Display(Name = "dogecoin")]
        Dogecoin, // c

        [Display(Name = "the-open-network")]
        Toncoin, // c

        [Display(Name = "cardano")]
        Cardano, // c

        [Display(Name = "shiba-inu")]
        ShibaInu, // c

        [Display(Name = "avalanche-2")]
        Avalanche, // c

        [Display(Name = "tron")]
        TRON, // c

        [Display(Name = "polkadot")]
        Polkadot, // c

        [Display(Name = "bitcoin-cash")]
        BitcoinCash, // c

        [Display(Name = "chainlink")]
        Chainlink, // c

        [Display(Name = "matic-network")]
        Polygon, // c

        [Display(Name = "near")]
        NEARProtocol, // c      

        [Display(Name = "internet-computer")]
        InternetComputer, // naoo funcionou

        [Display(Name = "litecoin")]
        Litecoin, // naoo funcionou

        [Display(Name = "uniswap")]
        Uniswap, // naoo funcionou

        [Display(Name = "aptos")]
        Aptos // c
    }
}
