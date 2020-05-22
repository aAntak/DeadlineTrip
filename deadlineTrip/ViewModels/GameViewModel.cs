using deadlineTrip.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace deadlineTrip.ViewModels
{
    public class GameViewModel
    {
        public Card Card { get; set; }
        public Game Game { get; set; }
        public Advertisement Ad{get;set;}
    }
}
