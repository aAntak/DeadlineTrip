using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace deadlineTrip.Models
{
    public interface IAdvertisementRepository
    {
        IEnumerable<Advertisement> GetAllAdvertisements();

    }
}
