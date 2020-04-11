using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace deadlineTrip.Models
{
    public class AdvertisementRepository : IAdvertisementRepository
    {
        private readonly AppDbContext _appDbContext;

        public AdvertisementRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Advertisement> AllAdvertisements
        {
            get
            {
                return _appDbContext.Advertisements;
            }
        }

    }
}
