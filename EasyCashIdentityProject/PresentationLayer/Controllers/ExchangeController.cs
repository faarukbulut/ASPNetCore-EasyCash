using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{
    public class ExchangeController : Controller
    {
        public async Task<IActionResult> Index()
        {
            #region
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://currency-exchange.p.rapidapi.com/exchange?from=USD&to=TRY&q=1.0"),
                Headers =
                {
                    { "X-RapidAPI-Key", "c80d8901c6msh4f312d49e88a4a7p17268cjsn4928d5204217" },
                    { "X-RapidAPI-Host", "currency-exchange.p.rapidapi.com" },
                },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                ViewBag.UsdToTry = body;
            }
            #endregion

            #region
            var client2 = new HttpClient();
            var request2 = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://currency-exchange.p.rapidapi.com/exchange?from=EUR&to=TRY&q=1.0"),
                Headers =
                {
                    { "X-RapidAPI-Key", "c80d8901c6msh4f312d49e88a4a7p17268cjsn4928d5204217" },
                    { "X-RapidAPI-Host", "currency-exchange.p.rapidapi.com" },
                },
            };
            using (var response2 = await client.SendAsync(request2))
            {
                response2.EnsureSuccessStatusCode();
                var body2 = await response2.Content.ReadAsStringAsync();
                ViewBag.EurToTry = body2;
            }
            #endregion

            #region
            var client3 = new HttpClient();
            var request3 = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://currency-exchange.p.rapidapi.com/exchange?from=GBP&to=TRY&q=1.0"),
                Headers =
                {
                    { "X-RapidAPI-Key", "c80d8901c6msh4f312d49e88a4a7p17268cjsn4928d5204217" },
                    { "X-RapidAPI-Host", "currency-exchange.p.rapidapi.com" },
                },
            };
            using (var response3 = await client.SendAsync(request3))
            {
                response3.EnsureSuccessStatusCode();
                var body3 = await response3.Content.ReadAsStringAsync();
                ViewBag.GbpToTry = body3;
            }
            #endregion








            return View();
        }
    }
}
