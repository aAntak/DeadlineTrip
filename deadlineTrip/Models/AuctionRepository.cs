using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
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

        public bool? CheckIfAuctionHasEnded(int auctionId)
        {
            var auction = _appDbContext.Auctions
                .FirstOrDefault(x => x.Id == auctionId);
            if (auction == null) return null;
            if (auction.EndDate <= DateTime.Now)
                return true;

            return false;
        }

        public IEnumerable<Auction> GetAll()
        {
            return _appDbContext.Auctions.Include(x => x.Bets).ToList();
        }

        public double? GetHighestBetForAuction(int auctionId)
        {
            var auction = _appDbContext.
                 Auctions.Include(x => x.Bets)
                .FirstOrDefault(x => x.Id == auctionId);
            if (auction == null) return null;
            if (auction.Bets.Count() == 0) return auction.StartingPrice;
            return auction.Bets.OrderByDescending(x => x.Date).First().Bet;
        }

        public IEnumerable<Auction> GetWonAuctions(string user)
        {
            return _appDbContext.Auctions.Include(x => x.Advertisement).ThenInclude(x => x.Card).Where(x => x.WinnerEmail == user);
            
        }

        public void RegisterBet(AuctionBet bet)
        {
            _appDbContext.AuctionBets.Add(bet);
            _appDbContext.SaveChanges();
        }

        public void setWinnerToAuction(int auctionId, string userId, double finalPrice)
        {
            var auction = _appDbContext.Auctions.FirstOrDefault(x => x.Id == auctionId);

            if (auction != null)
            {
                auction.FinalPrice = finalPrice;
                auction.WinnerEmail = userId;
            }
            _appDbContext.SaveChanges();
        }
    }
}
