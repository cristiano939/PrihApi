using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace PrihApi.Models
{
    [DataContract]
    public class BarData
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }
        [DataMember(Name = "name")]
        public string Name { get; set; }
        [DataMember(Name = "description")]
        public string Description { get; set; }
        [DataMember(Name = "address")]
        public string Address { get; set; }
        [DataMember(Name = "city")]
        public string City { get; set; }
        [DataMember(Name = "dlist")]
        public string DList { get; set; }
        [DataMember(Name = "lat")]
        public double Lat { get; set; }
        [DataMember(Name = "long")]
        public double Long { get; set; }
        [DataMember(Name = "likes")]
        public int Likes { get; set; }
        [DataMember(Name = "dontlikes")]
        public int DontLikes { get; set; }
        [DataMember(Name = "craftbeer")]
        public bool CraftBeer { get; set; }
        [DataMember(Name = "chopp")]
        public bool Chopp { get; set; }




    }
}