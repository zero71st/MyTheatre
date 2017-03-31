using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using Newtonsoft.Json;
using MyTheatre.Domain;

namespace MyTheatre.Web.Controllers
{
    public class HomeController : Controller
    {
        private HttpClient _apiClient;
        private readonly string _remoteServiceBaseUrl = "http://localhost:5000/api/videos";
        public async Task<IActionResult> Index()
        {
            _apiClient = new HttpClient();
            var dataString =  await _apiClient.GetStringAsync(_remoteServiceBaseUrl);

              var videos = JsonConvert.DeserializeObject<List<Video>>(dataString);

            return View(videos);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
