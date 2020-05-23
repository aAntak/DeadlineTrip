using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
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
            IEnumerable<Game> ads = _gameRepository.GetGames();
            var result = ads;
            return View("List", result);
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
            _gameRepository.Update(game.Id);
            if (game.GameVote == game.MaxVoteCount) 
            {
                ChangePrice(vote);
            }
            Game result = _gameRepository.GetCard(accountId);
            return View("GameScreen", result);
        }
        public void ChangePrice(GameVote vote) 
        {
            var Votes = _gameVoteRepository.GetVotes(vote.GameId);
            int decrease = 0;
            int increase = 0;
            foreach (GameVote i in Votes) 
            {
                if (i.Vote_type == 1)
                    decrease++;
                if (i.Vote_type == 3)
                    increase++;
            }
            if (decrease > increase) 
            {
                if ((decrease - increase) > 50)
                {
                    _advertisementRepository.ChangePriceAfterGame(false, vote.Game.CardId, 50);
                }
                else 
                {
                    _advertisementRepository.ChangePriceAfterGame(false, vote.Game.CardId, decrease-increase);
                }
            }
            if (decrease < increase) 
            {
                if ((increase - decrease) > 50)
                {
                    _advertisementRepository.ChangePriceAfterGame(true, vote.Game.CardId, 50);
                }
                else
                {
                    _advertisementRepository.ChangePriceAfterGame(true, vote.Game.CardId, increase - decrease);
                }
            }
            _gameVoteRepository.DeleteVotes(vote.GameId);
            _gameRepository.Delete(vote.GameId);
            _advertisementRepository.RemoveFromGame(vote.Game.CardId);
        }

        public ViewResult Delete(int Id)
        {
            Game games = _gameRepository.GetGame(Id);
            _gameVoteRepository.DeleteVotes(Id);
            _gameRepository.Delete(Id);
            _advertisementRepository.RemoveFromGame(games.CardId);
            IEnumerable<Game> ads = _gameRepository.GetGames();
            var result = ads;
            return View("List", result);
        }
    }
}
