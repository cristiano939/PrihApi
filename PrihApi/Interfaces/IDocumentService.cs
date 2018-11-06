using Lime.Protocol;
using PrihApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrihApi.Interfaces
{
    public interface IDocumentService
    {
        DocumentCollection CreateBarCarrossel(List<BarData> barsData, double myLat, double myLong);
    }
}
