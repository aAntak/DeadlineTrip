using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using deadlineTrip.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace deadlineTrip.Controllers
{
    public class PaymentController : Controller
    {
        private readonly IAdvertisementRepository _advertisementRepository;
        private readonly IShoppingCartRepository _shoppingCartRepository;
        private readonly ICardRepository _cardRepository;

        public PaymentController(IAdvertisementRepository advertisementRepository, IShoppingCartRepository shoppingCartRepository, ICardRepository cardRepository)
        {
            _advertisementRepository = advertisementRepository;
            _shoppingCartRepository = shoppingCartRepository;
            _cardRepository = cardRepository;
        }


        [HttpPost]
        public async Task<ActionResult> SubmitPaymentAction()
        {

            string apiUrl = "http://localhost:3000/PayForItem";

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(apiUrl);
                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();
                    var parsedData = (JObject)JsonConvert.DeserializeObject(data);
                    var result = parsedData["response"].ToString();

                    if (result.Equals("true"))
                    {
                        string accountId = HttpContext.Session.GetString("username"); //session
                        ShoppingCart cart = _shoppingCartRepository.GetShoppingCart(accountId);
                        _shoppingCartRepository.ClearCart(cart);
                        TempData["success"] = "Payment has been succesfull";
                        return RedirectToAction("Index", "ShoppingCart");
                    }

                }



            }

            TempData["error"] = "Payment failed. Try Again.";
            return RedirectToAction("Index", "ShoppingCart");
        }

    }
}
