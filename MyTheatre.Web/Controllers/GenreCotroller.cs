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
        private HttpClient _apiClient = new HttpClient();
        private readonly string _remoteServiceBaseUrl  = "http://localhost:5000/api/genres";

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var getGenresUrl = $"{_remoteServiceBaseUrl}/all";

            var dataString = await _apiClient.GetStringAsync(getGenresUrl);

            var genres = JsonConvert.DeserializeObject<List<GenreViewModel>>(dataString);

            if (genres == null)
                return NotFound();

            return View(genres);

        }
        
        public IActionResult CreateGenre()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateGenre([Bind("Id,Name")]GenreViewModel genre)
        {
            var createGenrnUrl = $"{_remoteServiceBaseUrl}/create";

            var contentString = new StringContent(JsonConvert.SerializeObject(genre),System.Text.Encoding.UTF8,"application/json");

            var response = await _apiClient.PostAsync(createGenrnUrl,contentString);

            return RedirectToAction("Index");
        }
    }
}