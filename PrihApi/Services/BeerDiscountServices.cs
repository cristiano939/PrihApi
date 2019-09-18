using PrihApi.Interfaces;
using PrihApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrihApi.Services
{
    public class BeerDiscountServices : IBeerDiscountServices
    {
        private readonly IBeerDiscountDBManager _beerDiscountDB;

        public BeerDiscountServices(IBeerDiscountDBManager beerDiscountDB)
        {
            _beerDiscountDB = beerDiscountDB;
        }
        public BarDiscountResponse InsertBeerDiscount(BeerDiscount beerDiscount)
        {
            var insertStatus = _beerDiscountDB.InsertBeerDiscount(beerDiscount);
            return new BarDiscountResponse { Success = insertStatus, SuccessDescription = insertStatus == true ? "Beer discount inserted" : "Beer discount wasn't inserted" };
        }
        public BarDiscountResponse RemoveBeerDiscount(long beerId)
        {
            var removeStatus = _beerDiscountDB.RemoveBeerDiscount(beerId);
            return new BarDiscountResponse { Success = removeStatus, SuccessDescription = removeStatus == true ? "Beer discount removed" : "Beer discount wasn't found" };
        }
        public BarDiscountResponse UpdateBeerDiscount(BeerDiscount beerDiscount)
        {
            var updateStatus = _beerDiscountDB.UpdateBeerDiscount(beerDiscount);
            return new BarDiscountResponse { Success = updateStatus, SuccessDescription = updateStatus == true ? "Beer discount updated" : "Beer discount wasn't updated" };
        }

        public BarDiscountResponse GetBeerDiscount(double latitude, double longitude, long radius)
        {
            var discountList = _beerDiscountDB.GetBeerDiscount(latitude, longitude, radius);
            return new BarDiscountResponse
            {
                Success = true,
                SuccessDescription = discountList != null ? "Beer discount found" : "Beer discount not found at your region",
                Discounts = discountList
            };
        }
    }
}
