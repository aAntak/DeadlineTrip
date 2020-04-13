using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace deadlineTrip.Models
{
    public class AdvertisementRepository : IAdvertisementRepository
    {
        private readonly AppDbContext _appDbContext;

        public List<Advertisement> Advertisements { get; set; }
        public string AccountId { get; set; }

        public AdvertisementRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public static AdvertisementRepository GetUser(IServiceProvider services)
        {
            ISession session = services.GetService<IHttpContextAccessor>()?
                .HttpContext.Session;

            var context = services.GetService<AppDbContext>();

            string accountId = session.GetString("username"); //?? Guid.NewGuid().ToString();
            session.SetString("username", accountId);

            return new AdvertisementRepository(context) { AccountId = accountId };
        }


        public IEnumerable<Advertisement> GetAllAdvertisements()
        {
            var allCards = _appDbContext.Card;
            var ads = Advertisements ??
                   (Advertisements =
                       _appDbContext.Advertisements.Where(c => c.AccountId == AccountId)
                           .ToList());
   
            return ads;
        }

        public void InsertRow(Advertisement ad)
        {
            _appDbContext.Advertisements.Add(ad);
            _appDbContext.SaveChanges();
        }



        

    }
}
