using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PrihApi.Interfaces;
using PrihApi.Models;

namespace PrihApi.Controllers
{
    [Route("Bar")]
    public class BarController : Controller
    {

        private readonly IPrihDBManager _prihDB;
        private readonly IDocumentService _documentService;
        private readonly IGMapsClient _gMaps;


        public BarController(IPrihDBManager prihDB, IDocumentService documentService, IGMapsClient gMaps)
        {
            _prihDB = prihDB;
            _documentService = documentService;
            _gMaps = gMaps;
        }

        [HttpPost]
        [Route("InsertBar")]
        public ActionResult InsertBar([FromBody] BarRequest barRequest)
        {
            try
            {
                var barData = new BarData
                {
                    Address = barRequest.Address,
                    Chopp = barRequest.Chopp == "Sim" ? true : false,
                    CraftBeer = barRequest.CraftBeer == "Sim" ? true : false,
                    Lat = double.Parse(barRequest.Lat.Replace(",", "."), CultureInfo.InvariantCulture),
                    Long = double.Parse(barRequest.Long.Replace(",", "."), CultureInfo.InvariantCulture),
                    Name = barRequest.Name
                };
                return Ok(barData);
                _prihDB.InsertBar(barData);
                return new StatusCodeResult(200);
            }
            catch (Exception ex)
            {
                throw (ex);

            }

        }
        [HttpGet]
        [Route("GetNearbyBarByLocation")]
        public ActionResult GetNearbyBarByLocation(string latitude, string longitude)
        {
            try
            {
                var lat = double.Parse(latitude.Replace(",", "."));
                var lng = double.Parse(longitude.Replace(",", "."));
                var nearbyBars = _prihDB.GetNearbyBarData(lat, lng);
                if (nearbyBars.Count > 0)
                {
                    var barsCarrossel = _documentService.CreateBarCarrossel(nearbyBars, lat, lng);


                    return Ok(barsCarrossel);
                }
                else
                {
                    return Ok("Sem resultados");
                }

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        [HttpGet]
        [Route("GetNearbyBarByAddress")]
        public async Task<ActionResult> GetNearbyBarByAddress(string address)
        {
            try
            {
                var geoResult = await _gMaps.GetAddressData(address);
                var latitude = geoResult.Results.FirstOrDefault().Geometry.Location.Lat.ToString();
                var longitude = geoResult.Results.FirstOrDefault().Geometry.Location.Lng.ToString();
                return GetNearbyBarByLocation(latitude, longitude);

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        [HttpGet]
        [Route("GetBarDetails")]
        public ActionResult GetBarDetails(int barId)
        {
            try
            {
                var barData = _prihDB.GetBarDetailsByID(barId);
                return Ok(barData);
            }
            catch (Exception ex)
            {
                throw (ex);
            }


        }

        [HttpPost]
        [Route("AddLikeonBar")]
        public ActionResult AddLikeOnBar(int barId)
        {
            try
            {
                var barData = _prihDB.GetBarDetailsByID(barId);
                barData.Likes += 1;
                _prihDB.UpdateBar(barData);
                return Ok(barData.Likes);
            }
            catch (Exception ex)
            {
                throw (ex);
            }


        }

        [HttpPost]
        [Route("AddDontLikeonBar")]
        public ActionResult AddDontLikeonBar(int barId)
        {
            try
            {
                var barData = _prihDB.GetBarDetailsByID(barId);
                barData.DontLikes += 1;
                _prihDB.UpdateBar(barData);
                return Ok(barData.DontLikes);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }


        [HttpPost]
        [Route("SendComment")]
        public ActionResult SendComment([FromBody] BarComment comment)
        {
            try
            {
                _prihDB.InsertComment(comment);
                return Ok();
            }
            catch (Exception ex)
            {
                throw (ex);
            }


        }
    }
}