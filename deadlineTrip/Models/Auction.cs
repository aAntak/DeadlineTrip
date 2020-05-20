using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace deadlineTrip.Models
{
    public class Auction
    {
        [Key]
        public int Id { get; set; }
        public double StartingPrice { get; set; }
        public double BuyNowPrice { get; set; }
        public DateTime EndDate { get; set; }
        public string WinnerEmail { get; set; } = null;
        public double? FinalPrice { get; set; } = null;

        public int AdvertisementId { get; set; }
        public virtual Advertisement Advertisement { get; set; }

    }
}
