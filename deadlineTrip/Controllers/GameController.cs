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
        public GameController(IAdvertisementRepository advertisementRepository,
            IGameRepository gameRepository)
        {
            _advertisementRepository = advertisementRepository;
            _gameRepository = gameRepository;
        }
        public ViewResult list() 
        {
            return View("List");
        }
    }
}
