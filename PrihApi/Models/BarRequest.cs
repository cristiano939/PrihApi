using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace PrihApi.Models
{
    [DataContract]
    public class BarRequest
    {
        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "address")]
        public string Address { get; set; }

        [DataMember(Name = "lat")]
        public string Lat { get; set; }
        [DataMember(Name = "long")]
        public string Long { get; set; }

        [DataMember(Name = "craftbeer")]
        public string CraftBeer { get; set; }
        [DataMember(Name = "chopp")]
        public string Chopp { get; set; }
    }
}
