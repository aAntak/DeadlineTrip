using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace deadlineTrip.Models
{
    public class AuctionRepository : IAuctionRepository
    {
        private readonly AppDbContext _appDbContext;

        public AuctionRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public bool AddCardToAuction(Auction auction)
        {
            try
            {
                _appDbContext.Auctions.Add(auction);
                _appDbContext.SaveChanges();
                return true;
            }catch(Exception e)
            {
                return false;
            }
        }

    }
}
