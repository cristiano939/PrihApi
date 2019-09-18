using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace PrihApi.Models
{
    [DataContract]
    public class BarDiscountResponse
    {
        [JsonProperty("success")]
        public bool Success { get; set; }
        [JsonProperty("successDescription")]
        public string SuccessDescription { get; set; }
        [JsonProperty("alert")]
        public Alert Alert { get; set; }
        [JsonProperty("discounts")]
        public List<BeerDiscount> Discounts { get; set; }
    }

    public class Alert
    {
        [JsonProperty("status")]
        public string AlertStatus { set; get; }
        [JsonProperty("description")]
        public string AlertDescription { set; get; }
    }
}
