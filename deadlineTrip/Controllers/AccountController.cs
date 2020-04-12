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
    //[Route("account")]
    public class AccountController : Controller
    {

        private readonly IAccountRepository _accountRepository;

        public AccountController(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }



        public IActionResult Index()
        {
            return View();
        }

       //[Route("login")]
        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            
           
            if (email != null && password != null)
            {
                var user = _accountRepository.GetUserByEmail(email);
                if (user != null && user.Password.Equals(password) && email.Equals(user.Id))
                {
                    HttpContext.Session.SetString("username", email);
                    return View("Success");
                }
            }   
                ViewBag.error = "Invalid Account";
                return View("Index");
            
        }

        //[Route("logout")]
        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("username");
            return RedirectToAction("Index");
        }
    }
}
