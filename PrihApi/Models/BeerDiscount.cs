using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace PrihApi.Models
{
    [DataContract]
    public class BeerDiscount
    {

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("price")]
        public double Price { get; set; }
        [JsonProperty("shopName")]
        public string ShopName { get; set; }
        [JsonProperty("shopAddress")]
        public string ShopAddress { get; set; }
        [JsonProperty("latitude")]
        public double Latitude { get; set; }
        [JsonProperty("longitude")]
        public double Longitude { get; set; }
        [JsonProperty("photoUri")]
        public string photoUri { get; set; }
        [JsonProperty("mapUri")]
        public string MapUri { get; set; }

    }
}
