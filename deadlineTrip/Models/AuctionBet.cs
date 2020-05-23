using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace deadlineTrip.Models
{
    public class AuctionBet
    {
        public int Id { get; set; }

        public double Bet { get; set; }

        public DateTime Date { get; set; }

        public string UserId { get; set; }

        public int AuctionId { get; set; }

        public virtual Auction Auction { get; set; }

    }
}
