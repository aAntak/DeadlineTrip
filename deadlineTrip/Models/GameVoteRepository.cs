using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace deadlineTrip.Models
{
    public class GameVoteRepository:IGameVoteRepository
    {
        private readonly AppDbContext _appDbContext;
        public List<GameVote> GameVotes { get; set; }
        public GameVoteRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public void SaveVote(GameVote gameVote) 
        {
            _appDbContext.GameVote.Add(gameVote);
            _appDbContext.SaveChanges();
        }
        public IEnumerable<GameVote> GetVotes(int id)
        {
            var votes = GameVotes ??
                   (GameVotes =
                       _appDbContext.GameVote.Where(c => c.GameId == id)
                           .ToList());
            return votes;
        }
        public void DeleteVotes(int id) 
        {
            var votes = GameVotes ??
                   (GameVotes =
                       _appDbContext.GameVote.Where(c => c.GameId == id)
                           .ToList());
            foreach (GameVote vote in votes) 
            {
                _appDbContext.Remove(vote);
            }
            _appDbContext.SaveChanges();
        }
    }
}
