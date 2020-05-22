using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace deadlineTrip.Models
{
    public class Game
    {
        public int Id { get; set; }
        public Card Card { get; set; }
        public int GameVote {get;set;}
        public int MaxVoteCount { get; set; }
    }
}
