using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace deadlineTrip.Models
{
    public class MockBankCards
    {
        [Required(ErrorMessage = "Card number is required")]

        [RegularExpression(@"^(?:4[0-9]{12}(?:[0-9]{3})?|5[1-5][0-9]{14}|6(?:011|5[0-9][0-9])[0-9]{12}|3[47][0-9]{13}|3(?:0[0-5]|[68][0-9])[0-9]{11}|(?:2131|1800|35\d{3})\d{11})$",
                            ErrorMessage = "Please enter a valid credit card number")]
       
        public string id { get; set; } //acc num

        [Required(ErrorMessage = "Full name is required")]
        public string FullName { get; set; }
        [Required(ErrorMessage = "Expiration date required")]
       
        [RegularExpression(@"^(0[1-9]|1[0-2])\/?([0 - 9]{4}|[0-9]{2})$",
                            ErrorMessage = "Please enter a valid expiration date (mm/yy)")]
        public string ValidThrough { get; set; }
        [Required(ErrorMessage = "CVV is required")]
        [Range(100, 999, ErrorMessage = "Invalid CVV")]
        public string cvv { get; set; }
    }
}
