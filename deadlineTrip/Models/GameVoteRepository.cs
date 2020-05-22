using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace deadlineTrip.Models
{
    public class GameVoteRepository:IGameVoteRepository
    {
        private readonly AppDbContext _appDbContext;
        public GameVoteRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public void SaveVote(GameVote gameVote) 
        {
            _appDbContext.GameVote.Add(gameVote);
            _appDbContext.SaveChanges();
        }
    }
}
