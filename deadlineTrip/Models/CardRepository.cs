using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace deadlineTrip.Models
{
    public class CardRepository : ICardRepository
    {

        public List<Card> Cards { get; set; }

        private readonly AppDbContext _appDbContext;

        public CardRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Card> getAllCards()
        {
            return Cards ??
                 (Cards =
                     _appDbContext.Card
                         .ToList());
            // Advertisements.Join(allCards, card => card.CardId, advertise)
        }


    }
}
