using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace deadlineTrip.Models
{
    public class GameRepository:IGameRepository
    {

        private readonly AppDbContext _appDbContext;
        public List<Game> Games { get; set; }
        public List<GameVote> GameVotes { get; set; }
        public GameRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public void AddCardToTheGame(Game game)
        {
            _appDbContext.Game.Add(game);
            _appDbContext.SaveChanges();
        }

        public Game GetCard(string userID) 
        {
            var games = Games ??
       (Games =
           _appDbContext.Game.Include(x => x.Card).ThenInclude(x => x.Card)
               .ToList());
                var votes = GameVotes ?? (GameVotes =
                                           _appDbContext.GameVote.Include(x => x.User).Include(x => x.Game).ToList());
                int i = 0;
                foreach (Game game in games)
                {
                    foreach (GameVote gameVote in votes)
                        {
                            if (game.Id == gameVote.GameId && userID == gameVote.UserId)
                            {
                                i++;
                            }
                        }
                    if (i == 0)
                    {
                        return game;
                    }
                    i = 0;
                }
                return null;
        }
        public void Update(int id) 
        {
            Game game = GetGame(id);
            if (game != null)
            {
                game.GameVote = game.GameVote + 1;
                _appDbContext.SaveChanges();
            }
        }
        public Game GetGame(int id)
        {
            Game ad = _appDbContext.Game
                .Include(x => x.Card)
                .SingleOrDefault(x => x.Id == id);

            return ad;
        }
        public void Delete(int id)
        {

            Game game = GetGame(id);

            _appDbContext.Remove(game);

            _appDbContext.SaveChanges();

        }
    }
}
