using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace deadlineTrip.Models.APIs
{
    public interface ICardSystemAPI
    {
        Task<double?> GetMarketPrice(string cardName);
    }
}
