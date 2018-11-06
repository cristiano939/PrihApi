using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace PrihApi.Models
{
    [DataContract]
    public class BarComment
    {
        [DataMember(Name = "barid")]
        public int BarId { get; set; }
        [DataMember(Name = "username")]
        public string UserName { get; set; }
        [DataMember(Name = "comment")]
        public string Comment { get; set; }


    }
}
