using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace deadlineTrip.Models
{
    public class ShoppingCartItem
    {
        public int ShoppingCartItemId { get; set; }
        public Advertisement ad { get; set; }
        public int quantity { get; set; }
        public int adId { get; set; }
        public ShoppingCart ShoppingCartId { get; set; }
    }
}
