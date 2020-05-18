using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace deadlineTrip.Models
{
    public class MockBankCardsRepository : IMockBankCardsRepository
    {
        private readonly AppDbContext _appDbContext;

        public List<MockBankCards> BankCards { get; set; }

        public MockBankCardsRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public MockBankCards GetBankCard(string cardNumber)
        {
            MockBankCards bankCard = _appDbContext.MockBankCards.SingleOrDefault(x => x.id == cardNumber);

            return bankCard;
        }

    }
}
