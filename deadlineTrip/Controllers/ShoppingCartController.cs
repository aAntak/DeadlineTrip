using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using deadlineTrip.Migrations;
using deadlineTrip.Models;
using deadlineTrip.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace deadlineTrip.Controllers
{
    public class ShoppingCartController : Controller
    {

        private readonly IAdvertisementRepository _advertisementRepository;
        private readonly IShoppingCartRepository _shoppingCartRepository;
        private readonly ICardRepository _cardRepository;
        private readonly IMockBankCardsRepository _bankCardRepository;
        public ShoppingCartController(IAdvertisementRepository advertisementRepository, IShoppingCartRepository shoppingCartRepository, ICardRepository cardRepository, IMockBankCardsRepository bankCardRepository)
        {
            _advertisementRepository = advertisementRepository;
            _shoppingCartRepository = shoppingCartRepository;
            _cardRepository = cardRepository;
            _bankCardRepository = bankCardRepository;
        }

        public ViewResult Index()
        {

            string accountId = HttpContext.Session.GetString("username"); //session
            ShoppingCart cart = _shoppingCartRepository.GetShoppingCart(accountId);
            
            IEnumerable<ShoppingCartItem> items = _shoppingCartRepository.GetShoppingCartItems(cart.ShoppingCartId);
            IEnumerable<Advertisement> ads = _advertisementRepository.GetAllAdvertisements();
            IEnumerable<Card> cards = _cardRepository.getAllCards();

            return View("CartIndex", items);
        }



        public ActionResult AddToCart(int advertisementId)
        {
            string accountId = HttpContext.Session.GetString("username"); //session
            ShoppingCart cart = _shoppingCartRepository.GetShoppingCart(accountId);
            Advertisement ad = _advertisementRepository.GetAdvertisement(advertisementId);

            ShoppingCartItem item = new ShoppingCartItem { ShoppingCartId= cart, ad = ad };

            _shoppingCartRepository.AddToCart(ad, cart);
            TempData["success"] = "The card has been succesfully added to your cart";
            return RedirectToAction("list", "Advertisement");
        }

        public ActionResult Delete(int id)
        {
            _shoppingCartRepository.Delete(id);
            TempData["success"] = "Item has been deleted succesfully";
            return RedirectToAction("Index");
        }

        public ActionResult CheckOut()
        {
            string accountId = HttpContext.Session.GetString("username"); //session
            ShoppingCart cart = _shoppingCartRepository.GetShoppingCart(accountId);
            IEnumerable<ShoppingCartItem> items = _shoppingCartRepository.GetShoppingCartItems(cart.ShoppingCartId);
            IEnumerable<Advertisement> ad = _advertisementRepository.GetAllAdvertisements();
            decimal sum = 0;
            foreach(ShoppingCartItem item in items)
            {
                sum += (item.ad.Price * item.quantity);
            }

            ShoppingCartViewModel result = new ShoppingCartViewModel { ShoppingCart = cart, ShoppingCartTotal = sum };


            return PartialView("~/Views/Payment/Index.cshtml", result);
        }

        [HttpPost]
        public ActionResult SubmitPaymentAction(IFormCollection collection)
        {

            if (ModelState.IsValid)
            {
                string cardNumber = collection["MockBankCards.id"];
                string fullName = collection["MockBankCards.FullName"];
                string validThrough = collection["MockBankCards.ValidThrough"];
                string cvv = collection["MockBankCards.cvv"];

                MockBankCards bankCard = _bankCardRepository.GetBankCard(cardNumber);

                if (bankCard != null)
                {
                    if (bankCard.FullName == fullName && bankCard.ValidThrough == validThrough && bankCard.cvv == cvv)
                    {
                        string accountId = HttpContext.Session.GetString("username"); //session
                        ShoppingCart cart = _shoppingCartRepository.GetShoppingCart(accountId);
                        _shoppingCartRepository.ClearCart(cart);
                        TempData["success"] = "Payment has been succesfull";
                        return RedirectToAction("Index");
                    }
                }
            }

            TempData["error"] = "Payment failed. Try Again.";
            return RedirectToAction("Index");
        }



    }
}
