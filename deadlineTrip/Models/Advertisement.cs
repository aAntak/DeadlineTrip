using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace deadlineTrip.Models
{
    public class Advertisement
    {
        public int Id { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a value bigger than {1}")]
        public decimal Price { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a value bigger than {1}")]
        public int Quantity { get; set; }

        public string AccountId { get; set; }
        [ForeignKey("Card")]
        public int CardId { get; set; }
        public Card Card { get; set; }
        public bool IsInGame { get; set; }
        public Auction Auction { get; set; }
        
        
    }
    
}
