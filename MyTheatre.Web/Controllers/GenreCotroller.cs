using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using MyTheatre.Web.ViewModels;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace MyTheatre.Web.Controllers
{

    public class GenreController : Controller
    {
        private HttpClient _apiClient;
        private readonly string _remoteServiceBaseUrl  = "http://192.168.99.100/api/genres";

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            _apiClient = new HttpClient();

            var getGenresUrl = $"{_remoteServiceBaseUrl}/all";

            var dataString = await _apiClient.GetStringAsync(getGenresUrl);

            var genres = JsonConvert.DeserializeObject<List<GenreViewModel>>(dataString);

            if (genres == null)
                return NotFound();

            return View(genres);

        }
    }
}