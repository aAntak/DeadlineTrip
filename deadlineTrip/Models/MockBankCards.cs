using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace deadlineTrip.Models
{
    public class MockBankCards
    {
        public string id { get; set; } //acc num
        public string FullName { get; set; }
        public string ValidThrough { get; set; }
        public string cvv { get; set; }
    }
}
