using PrihApi.Interfaces;
using PrihApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrihApi.Services
{
    public class BeerDiscountDBManager : IBeerDiscountDBManager
    {
        public bool InsertBeerDiscount(BeerDiscount beerDiscount)
        {
            return true;
        }

        public bool RemoveBeerDiscount(long beerId)
        {
            return true;
        }
        public bool UpdateBeerDiscount(BeerDiscount beerDiscount)
        {
            return true;
        }

        public List<BeerDiscount> GetBeerDiscount(double latitude, double longitude, long radius)
        {
            return new List<BeerDiscount>();
        }
    }
}
