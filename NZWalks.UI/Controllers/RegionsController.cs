using Microsoft.AspNetCore.Mvc;
using NZWalks.UI.Models.DTO;
using System.Security.Cryptography.X509Certificates;

namespace NZWalks.UI.Controllers
{
    public class RegionsController : Controller
    {
        private readonly IHttpClientFactory httpClientFactory;

        public RegionsController(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> Index()
        {
            List<RegionDto> response = new List<RegionDto>();
            //Get all regions from web API
            try
            {
                var client = httpClientFactory.CreateClient();

                var httpResponseMessage = await client.GetAsync("https://localhost:7211/api/regions");

                httpResponseMessage.EnsureSuccessStatusCode();

                response.AddRange(await httpResponseMessage.Content.ReadFromJsonAsync<IEnumerable<RegionDto>>());
                
            }
            catch (Exception ex)
            {

                //Log the exception 
            }

            return View(response);
        }
    }
}
