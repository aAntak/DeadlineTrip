using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using deadlineTrip.Models;
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

        //  AddScope injects repositories into controller
        //when class requires these types they will be injected auto
        // by the built-in dependecy injection system
        public AdvertisementController(IAdvertisementRepository advertisementRepository, IAccountRepository accountRepository, ICardRepository cardRepository)
        {
            _advertisementRepository = advertisementRepository;
            _accountRepository = accountRepository;
            _cardRepository = cardRepository;
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
            AdsListViewModel result = new AdsListViewModel { Cards = card, Advertisements = ad };

            return PartialView("CardDetailsPartial", result);
        }



    }
}
