﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using deadlineTrip.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace deadlineTrip.Controllers
{
    public class AdvertisementController : Controller
    {
        // GET: /<controller>/
        private readonly IAdvertisementRepository _advertisementRepository;
        private readonly IAccountRepository _accountRepository;

        //  AddScope injects repositories into controller
        //when class requires these types they will be injected auto
        // by the built-in dependecy injection system
        public AdvertisementController(IAdvertisementRepository advertisementRepository, IAccountRepository accountRepository)
        {
            _advertisementRepository = advertisementRepository;
            _accountRepository = accountRepository;
        }
        public ViewResult List()
        {

            return View(_advertisementRepository.GetAllAdvertisements());
        }


    }
}
