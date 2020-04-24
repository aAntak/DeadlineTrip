using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace deadlineTrip.Models
{
    public interface IAdvertisementRepository
    {
        IEnumerable<Advertisement> GetAllAdvertisements();
        void InsertRow(Advertisement ad);
        void Delete(int id);
        Advertisement GetAdvertisement(int id);
        void Update(int id, int quantity, decimal price);

    }
}
