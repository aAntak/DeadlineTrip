using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using deadlineTrip.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace deadlineTrip.Controllers
{
    public class CardController : Controller
    {
         // GET: /<controller>/
        private readonly ICardRepository _cardRepository;

        //  AddScope injects repositories into controller
        //when class requires these types they will be injected auto
        // by the built-in dependecy injection system
        public CardController(ICardRepository cardRepository)
        {
            _cardRepository = cardRepository;
        }

        public JsonResult AjaxGetCards()
        {
            return Json(_cardRepository.getAllCards());
        }
        public ViewResult List()
        {

            return View(_cardRepository.getAllCards());
        }
        public ActionResult CardDetails(int id)
        {

            Card card = _cardRepository.GetCard(id);
            return PartialView("CardDetailsPartial", card);
        }
    }
}
