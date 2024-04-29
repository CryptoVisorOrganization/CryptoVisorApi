using CryptoVisor.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoVisor.Application.Interfaces
{
	public interface IOhlcRepository
	{
		Task SaveListAsync(List<OhclCoinHistory> dataList);
	}
}
