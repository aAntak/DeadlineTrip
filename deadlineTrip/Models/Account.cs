using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace deadlineTrip.Models
{
    public class Account
    {

        public string Id { get; set; } //email kaip pk?
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public DateTime BirthDate { get; set; }
        public List<Advertisement> Advertisements { get; set; }

    }
}
