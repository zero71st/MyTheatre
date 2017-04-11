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
        private readonly string _remoteServiceBaseUrl  = "http://192.168.99.100/api/genres";

        [HttpGet]
        [ActionName("Index")]
        public async Task<IActionResult> ListGenresAsync()
        {
            var getGenresUrl = $"{_remoteServiceBaseUrl}/all";
            var dataString = await _apiClient.GetStringAsync(getGenresUrl);
            var genres = JsonConvert.DeserializeObject<List<GenreViewModel>>(dataString);

            if (genres == null)
                return NotFound();

            return View(genres);

        }
        
        [HttpGet]
        public IActionResult CreateGenre()
        {
            return View();
        }

        [HttpPost]
        [ActionName("CreateGenre")]
        public async Task<IActionResult> CreateGenreAsync([Bind("Id,Name")]GenreViewModel genre)
        {
            var createGenrnUrl = $"{_remoteServiceBaseUrl}/create";
            var contentString = new StringContent(JsonConvert.SerializeObject(genre),System.Text.Encoding.UTF8,"application/json");
            var response = await _apiClient.PostAsync(createGenrnUrl,contentString);

            return RedirectToAction("Index");
        }

        [HttpGet]
        [ActionName("UpdateGenre")]
        public async Task<IActionResult> UpdateGenreAsync(int id)
        {
            var getUrl = $"{_remoteServiceBaseUrl}/{id}";
            var dataString = await _apiClient.GetStringAsync(getUrl);
            var genre = JsonConvert.DeserializeObject<GenreViewModel>(dataString);

            return View(genre);
        }

        [HttpPost]
        [ActionName("UpdateGenre")]
        public async Task<IActionResult> UpdateGenreAsync(int id,[Bind("Id,Name")]GenreViewModel genre)
        {
            var updateUrl = $"{_remoteServiceBaseUrl}/update";
            var contentString = new StringContent(JsonConvert.SerializeObject(genre),System.Text.Encoding.UTF8,"application/Json");
            var response = await _apiClient.PostAsync(updateUrl,contentString);

            return RedirectToAction("Index");
        }
    }
}