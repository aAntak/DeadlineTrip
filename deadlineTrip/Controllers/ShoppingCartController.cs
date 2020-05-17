using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using deadlineTrip.Models;
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
        public ShoppingCartController(IAdvertisementRepository advertisementRepository, IShoppingCartRepository shoppingCartRepository, ICardRepository cardRepository)
        {
            _advertisementRepository = advertisementRepository;
            _shoppingCartRepository = shoppingCartRepository;
            _cardRepository = cardRepository;
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

    }
}
