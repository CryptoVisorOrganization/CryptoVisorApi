using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoVisor.Core.ValueObjects
{
    public class BollingerBands
    {
        public DateTime Date {  get; set; }
        public double Higher {  get; set; }
        public double Lower { get; set; }
        public double Base { get; set; }
    }
}
