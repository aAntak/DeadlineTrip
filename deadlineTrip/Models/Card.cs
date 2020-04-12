using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace deadlineTrip.Models
{
    public class Card
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }
        public int Level { get; set; }
        public Retumas Retumas { get; set; }


    }
}

