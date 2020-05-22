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
        private readonly IGameVoteRepository _gameVoteRepository;
        private readonly IAccountRepository _accountRepository;
        public GameController(IAdvertisementRepository advertisementRepository,
                              IGameRepository gameRepository,
                              IGameVoteRepository gameVoteRepository,
                              ICardRepository cardRepository,
                              IAccountRepository accountRepository)
        
        {
            _advertisementRepository = advertisementRepository;
            _gameRepository = gameRepository;
            _gameVoteRepository = gameVoteRepository;
            _cardRepository = cardRepository;
            _accountRepository = accountRepository;
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
        public ViewResult Vote(int value, int id) 
        {
            Game game = _gameRepository.GetGame(id);
            string accountId = HttpContext.Session.GetString("username");
            Account acc = _accountRepository.GetUserByEmail(accountId);
            GameVote vote = new GameVote { Game = game, User = acc, Vote_type = value};
            _gameVoteRepository.SaveVote(vote);
            Game result = _gameRepository.GetCard(accountId);
            return View("GameScreen", result);
        }
    }
}
