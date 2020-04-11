using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace deadlineTrip.Models
{
    public class Advertisement
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        public Card Card { get; set; }
    }
}
