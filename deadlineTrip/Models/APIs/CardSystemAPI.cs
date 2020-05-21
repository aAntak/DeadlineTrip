using deadlineTrip.Models.APIs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestSharp;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace deadlineTrip.Models
{
    public class CardSystemAPI : ICardSystemAPI
    {
        private readonly string BASE_API = "https://db.ygoprodeck.com/api/v7/cardinfo.php";
        public async Task<double?> GetMarketPrice(string cardName)
        {
            var client = new RestClient($"{BASE_API}?name={cardName}");
            var request = new RestRequest(Method.GET);
            IRestResponse response = await client.ExecuteAsync(request);
            if (response.IsSuccessful)
            {
                var content = JsonConvert.DeserializeObject<JObject>(response.Content);
                try
                {
                    var data = (JObject) content["data"][0]["card_prices"][0];
                    var sum = 0.0;
                    int shopsFound = 0;
                    foreach(var price in data)
                    {
                        try
                        {
                            sum += (double) price.Value;
                            shopsFound++;
                        }catch(Exception e)
                        {
                            continue;
                        }
                    }
                    return sum / shopsFound;
                }
                catch
                {
                    return null;
                }
            }
            return null;
        }
    }
}
