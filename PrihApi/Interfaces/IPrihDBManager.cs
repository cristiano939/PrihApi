using PrihApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrihApi.Interfaces
{
    public interface IPrihDBManager
    {
        bool InsertBar(BarData barData);
        List<BarData> GetNearbyBarData(double latitude, double longitude);

        BarData GetBarDetailsByID(int Id);

        bool UpdateBar(BarData barData);
        bool InsertComment(BarComment barComment);
    }
}
