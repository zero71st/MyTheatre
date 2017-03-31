using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;

namespace MyTheatre.Web.Controllers
{
    public class HomeController : Controller
    {
        private HttpClient _apiClient;
        private readonly string _remoteServiceBaseUrl = "http://192.168.99.100:5000/api/videos";
        public IActionResult Index()
        {
            _apiClient = new HttpClient();
            var result = _apiClient.GetStringAsync(_remoteServiceBaseUrl);
            return View(result);
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
