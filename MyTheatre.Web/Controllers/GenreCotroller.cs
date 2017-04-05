using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using MyTheatre.Web.ViewModels;
using System.Threading.Tasks;

namespace MyTheatre.Web.Controllers
{

    public class GenreController : Controller
    {
        private readonly HttpClient _apiClient = new HttpClient();
        private readonly string _remoteServiceBaseUrl  = "http://192.168.99.100/api/genres";

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var dataString = await _apiClient.GetStringAsync(_remoteServiceBaseUrl);

            var genres = JsonConvert.DeserializeObject<GenreViewModel>(dataString);
            if (genres == null)
                return NotFound();

            return Ok(genres);

        }
    }
}