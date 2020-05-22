using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using deadlineTrip.Models;
using deadlineTrip.Models.APIs;
using deadlineTrip.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace deadlineTrip.Controllers
{
    public class GameController : Controller
    {
        private readonly IGameRepository _gameRepository;
        private readonly IAdvertisementRepository _advertisementRepository;
        private readonly ICardRepository _cardRepository;
        public GameController(IAdvertisementRepository advertisementRepository,
                              IGameRepository gameRepository,
                              ICardRepository cardRepository)
        
        {
            _advertisementRepository = advertisementRepository;
            _gameRepository = gameRepository;
            _cardRepository = cardRepository;
        }
        public ViewResult list() 
        {

            return View("List");
        }
        public ViewResult OpenGame()
        {
            string accountId = HttpContext.Session.GetString("username");
            Game result = _gameRepository.GetCard(accountId);

            return View("GameScreen", result);
        }
    }
}
