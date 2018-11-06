using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using PrihApi.Interfaces;
using PrihApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace PrihApi.Services
{
    public class GMapsClient : IGMapsClient
    {
        private readonly IConfiguration _configuration;

        public GMapsClient(IConfiguration configuration)
        {
            _configuration = configuration;
        }



        public async Task<GeoCodingResult> GetAddressData(string address)
        {
            using (var client = new HttpClient())
            {
                var taskResult = await client.GetAsync(string.Format(_configuration["gmapsconfig:geocodingurl"], address));
                var result = JsonConvert.DeserializeObject<GeoCodingResult>(await taskResult.Content.ReadAsStringAsync());

                return result;
            }
        }

        //public async Task<GDistanceData> GetDistanceData(string oLat, string oLng, string dLat, string dLng)
        //{
        //    using (var client = GetClient(GeoCodeApiKey, new Uri(GeoCodeBaseAddress)))
        //    {
        //        var taskResult = await client.GetAsync(client.BaseAddress + string.Format(DistancePattern, oLat + "," + oLng, dLat + "," + dLng, "driving", GMapsDistMatrixApiKey));
        //        var GDistData = JsonConvert.DeserializeObject<GDistanceData>(taskResult.Content.ReadAsStringAsync().Result);

        //        return GDistData;
        //    }



        //}
    }
}