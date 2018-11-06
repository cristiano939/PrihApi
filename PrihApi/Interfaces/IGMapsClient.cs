using PrihApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrihApi.Interfaces
{
    public interface IGMapsClient
    {
        Task<GeoCodingResult> GetAddressData(string address);
    }
}
