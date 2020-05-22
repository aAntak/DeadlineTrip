using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace deadlineTrip.Models
{
    public class GameVote
    {
        public int Id { get; set; }
        public Game Game { get; set; }
        public Account User { get; set; }
        public Vote_type Vote_type { get; set; }
    }
}
