using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using deadlineTrip.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace deadlineTrip.Controllers
{
    public class AuctionController : Controller
    {
        private readonly IAuctionRepository _auctionRepo;

        public AuctionController(IAuctionRepository auctionRepo)
        {
            _auctionRepo = auctionRepo;
        }

        [HttpPost]
        public ActionResult SubmitCreateAction([FromBody] Auction auction)
        {
            if (_auctionRepo.AddCardToAuction(auction))
            {
                return Ok();
            }
            else
                return BadRequest();
        }
    }
}
