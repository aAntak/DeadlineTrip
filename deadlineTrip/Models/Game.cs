using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace deadlineTrip.Models
{
    public class Game
    {
        public int Id { get; set; }
        public Advertisement Card { get; set; }
        [ForeignKey("Card")]
        public int CardId { get; set; }
        public int GameVote {get;set;}
        public int MaxVoteCount { get; set; }
    }
}
