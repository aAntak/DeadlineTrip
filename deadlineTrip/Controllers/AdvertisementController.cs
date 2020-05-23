using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using deadlineTrip.Models;
using deadlineTrip.Models.APIs;
using deadlineTrip.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace deadlineTrip.Controllers
{
    public class AdvertisementController : Controller
    {
        // GET: /<controller>/
        private readonly IAdvertisementRepository _advertisementRepository;
        private readonly IAccountRepository _accountRepository;
        private readonly ICardRepository _cardRepository;
        private readonly ICardSystemAPI _cardsAPI;
        private readonly IAuctionRepository _auctionRepo;
        private readonly IGameRepository _gameRepository;


        //  AddScope injects repositories into controller
        //when class requires these types they will be injected auto
        // by the built-in dependecy injection system
        public AdvertisementController(IAdvertisementRepository advertisementRepository,
                                       IAccountRepository accountRepository,
                                       ICardRepository cardRepository,
                                       ICardSystemAPI cardsAPI,
                                       IAuctionRepository auctionRepo,
                                       IGameRepository gameRepository)
        {
            _advertisementRepository = advertisementRepository;
            _accountRepository = accountRepository;
            _cardRepository = cardRepository;
            _cardsAPI = cardsAPI;
            _auctionRepo = auctionRepo;
            _gameRepository = gameRepository;
        }
        public ViewResult userAdList()
        {

            IEnumerable<Advertisement> ads = _advertisementRepository.GetAllUserAdvertisements();
            IEnumerable<Card> cards = _cardRepository.getAllCards();

            var results = (from p in cards
                           join pm in ads on p.Id equals pm.CardId
                           select new AdsListViewModel{ Cards = p, Advertisements = pm });
            return View(results);
        }

        public ViewResult list()
        {

            IEnumerable<Advertisement> ads = _advertisementRepository.GetAllAdvertisements();
            IEnumerable<Card> cards = _cardRepository.getAllCards();

            var results = (from p in cards
                           join pm in ads on p.Id equals pm.CardId
                           select new AdsListViewModel { Cards = p, Advertisements = pm });
            
            return View("userAdList", results);
        }

        public ViewResult Create()
        {
            ViewBag.Cards = _cardRepository.getAllCards().Select(x=>x.Name).ToArray();

            return View();
        }
        

        [HttpPost]
        public ActionResult SubmitCreateAction(IFormCollection collection)
        {
            // Get Post Params Here
            if (ModelState.IsValid)
            {
                int cardId = Convert.ToInt32(collection["Advertisements.CardId"]);
                int quantity = Convert.ToInt32(collection["Advertisements.Quantity"]);
                decimal price = Convert.ToInt32(collection["Advertisements.Price"]);
                string accountId = HttpContext.Session.GetString("username");


                Advertisement ad = new Advertisement { Price = price, Quantity = quantity, AccountId = accountId, CardId = cardId };
                _advertisementRepository.InsertRow(ad);

                TempData["success"] = "Advertisement has been added succesfully";
                return RedirectToAction("userAdList", "Advertisement");
            }
            //Account id session
            //public int CardId =
            // card = _cardRepository.

            return View();
            
        }

        public ActionResult Delete(int id)
        {
            _advertisementRepository.Delete(id);
            TempData["success"] = "Advertisement has been deleted succesfully";
            return RedirectToAction("userAdList", "Advertisement");
        }

        public ActionResult EditAdvertisement(int id)
        {
            
            Advertisement ad = _advertisementRepository.GetAdvertisement(id);
            int cardId = ad.CardId;
            Card card = _cardRepository.GetCard(cardId);
            AdsListViewModel result = new AdsListViewModel { Cards = card, Advertisements = ad};
            return PartialView("Partial2", result);
        }

        [HttpPost]
        public ActionResult SubmitEditAction(IFormCollection collection)
        {

            int quantity = Convert.ToInt32(collection["Advertisements.Quantity"]);
            decimal price = Convert.ToDecimal(collection["Advertisements.Price"]);
            int id = Convert.ToInt32(collection["Advertisements.Id"]);



            _advertisementRepository.Update(id, quantity, price);


            TempData["success"] = "Advertisement has been edited succesfully";
            return RedirectToAction("userAdList", "Advertisement");
        }

        public ActionResult AdvertisementDetails(int id)
        {
            Advertisement ad = _advertisementRepository.GetAdvertisement(id);
            int cardId = ad.CardId;
            Card card = _cardRepository.GetCard(cardId);

            AdsListViewModel result = new AdsListViewModel { Cards = card,
                                                            Advertisements = ad, 
                                                            ifInAuction = ad.Auction == null ? false : true,
                                                            HasAuctionFinished = HasAuctionFinished(ad.Auction)

            };

            return PartialView("CardDetailsPartial", result);
        }

        public async Task<ActionResult> GetMarketPrice(int cardId, int adId)
        {
            var card = _cardRepository.GetCard(cardId);
            var marketPrice = await _cardsAPI.GetMarketPrice(card.Name);

            return Json(marketPrice);
        }

        public ActionResult AddToTheGame (int id)
        {
            Advertisement ad = _advertisementRepository.GetAdvertisement(id);
            Game game = new Game { Card = ad,GameVote = 0, MaxVoteCount = 5 };
            _gameRepository.AddCardToTheGame(game);
            _advertisementRepository.AddToTheGame(id);
            return RedirectToAction("userAdList", "Advertisement");
        }
        public ActionResult ApproveMarketPrice(decimal price, int advertisement)
        {
            var ad = _advertisementRepository.GetAdvertisement(advertisement);
            _advertisementRepository.Update(ad.Id, ad.Quantity, price);
            return Ok();
        }

        [HttpPost]
        public ActionResult PlaceBet(double? newPrice, int auctionId)
        {
            if(newPrice == null || _auctionRepo.GetHighestBetForAuction(auctionId) >= newPrice)
                return BadRequest("Bet error");

            if (_auctionRepo.CheckIfAuctionHasEnded(auctionId) == true)
                return BadRequest("Auction has ended");

            var userId = HttpContext.Session.GetString("username");
            _auctionRepo.RegisterBet(new AuctionBet
            {
                Date = DateTime.Now,
                UserId = userId,
                AuctionId = auctionId,
                Bet = newPrice.Value
            });
            return Ok();
        }
        private bool HasAuctionFinished(Auction auction)
        {
            if (auction == null) return true;
            if (auction.EndDate > DateTime.Now) return false;
            return true;
        }

    }
}
