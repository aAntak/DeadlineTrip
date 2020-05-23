using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace deadlineTrip.Models
{
    public interface IGameRepository
    {
        void AddCardToTheGame(Game game);
        Game GetCard(string userID);
        Game GetGame(int id);
        void Update(int id);
        void Delete(int id);
        IEnumerable<Game> GetGames();
    }
}
