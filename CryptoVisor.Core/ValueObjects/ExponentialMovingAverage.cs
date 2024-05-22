using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoVisor.Core.ValueObjects
{
    public class ExponentialMovingAverage
    {
        public DateTime Date {  get; set; }
        public double Value { get; set; }
    }
}
