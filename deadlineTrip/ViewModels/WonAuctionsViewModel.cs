using deadlineTrip.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace deadlineTrip.ViewModels
{
    public class WonAuctionsViewModel
    {
       public IEnumerable<Auction> Auctions { get; set; }
    }
}
