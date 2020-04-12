using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace deadlineTrip.Models
{
    public class AccountRepository : IAccountRepository
    {

        private readonly AppDbContext _appDbContext;

        public AccountRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public Account GetUserByEmail(string Email)
        {
            return _appDbContext.Accounts.FirstOrDefault(x => x.Id == Email);
        }


    }
}
