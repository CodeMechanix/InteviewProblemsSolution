using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrackingCode.StockData
{
    public class StockRequestInfo
    {
        public Action OnComplete { get; set; }
        public object Data { get; set; }
    }
}

