using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace deadlineTrip.Models
{
   public interface IAuctionRepository
    {
        bool AddCardToAuction(Auction auction);

        double? GetHighestBetForAuction(int auctionId);
        bool? CheckIfAuctionHasEnded(int auctionId);
        void RegisterBet(AuctionBet bet);
        IEnumerable<Auction> GetWonAuctions(string user);

        //
        IEnumerable<Auction> GetAll();

        void setWinnerToAuction(int auctionId, string userId, double finalPrice);

    }
}
