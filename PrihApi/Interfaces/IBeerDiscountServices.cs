using PrihApi.Models;
using System.Collections.Generic;

namespace PrihApi.Interfaces
{
    public interface IBeerDiscountServices
    {
        BarDiscountResponse InsertBeerDiscount(BeerDiscount beerDiscount);
        BarDiscountResponse RemoveBeerDiscount(long beerId);
        BarDiscountResponse UpdateBeerDiscount(BeerDiscount beerDiscount);
        BarDiscountResponse GetBeerDiscount(double latitude, double longitude, long radius);

    }
}