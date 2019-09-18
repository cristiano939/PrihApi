using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PrihApi.Interfaces;
using PrihApi.Models;

namespace PrihApi.Controllers
{
    [Route("BeerDiscount")]
    public class BeerDiscountController : Controller
    {
        private readonly IBeerDiscountServices _beerDiscountServices;

        public BeerDiscountController(IBeerDiscountServices beerDiscountServices)
        {
            _beerDiscountServices = beerDiscountServices;
        }
        [HttpGet]
        public IActionResult BeerDiscount(double latitude, double longitude, int distanceRadius = 5)
        {
            return Ok(_beerDiscountServices.GetBeerDiscount(latitude, longitude, distanceRadius));
        }

        [HttpPost]
        public IActionResult BeerDiscount([FromBody] BeerDiscount beerDiscount)
        {
            return Ok(_beerDiscountServices.InsertBeerDiscount(beerDiscount));
        }

        [HttpDelete]
        public IActionResult BeerDiscount(int beerId)
        {
            return Ok(_beerDiscountServices.RemoveBeerDiscount(beerId));
        }

        [HttpPut]
        public IActionResult PutBeerDiscount([FromBody] BeerDiscount beerDiscount)
        {
            return Ok(_beerDiscountServices.UpdateBeerDiscount(beerDiscount));
        }

    }
}