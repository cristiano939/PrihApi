using PrihApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrihApi.Interfaces
{
    public interface IBeerDiscountDBManager
    {
        bool InsertBeerDiscount(BeerDiscount beerDiscount);
        bool RemoveBeerDiscount(long beerId);
        bool UpdateBeerDiscount(BeerDiscount beerDiscount);
        List<BeerDiscount> GetBeerDiscount(double latitude, double longitude, long radius);
    }
}
