using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrihApi.Exceptions
{
    public abstract class BeerException
    {
        public string ErrorMsg { get; set; }
        public string StatusCode { get; set; }
    }
}
