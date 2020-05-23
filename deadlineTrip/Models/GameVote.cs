using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace deadlineTrip.Models
{
    public class GameVote
    {
        public int Id { get; set; }
        public Game Game { get; set; }
        [ForeignKey("Game")]
        public int GameId { get; set; }
        public Account User { get; set; }
        [ForeignKey("User")]
        public string UserId { get; set; }
        public int Vote_type { get; set; }
    }
}
