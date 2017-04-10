using System;
using System.Collections.Generic;
using MyTheatre.Domain;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using Newtonsoft.Json;
using MyTheatre.Web.ViewModels;

namespace MyTheatre.Web.Controllers
{
    public class HomeController : Controller
    {
        private HttpClient _apiClient;
        private readonly string _remoteServiceBaseUrl = "http://192.168.99.100/api/videos";
        public async Task<IActionResult> Index()
        {
            _apiClient = new HttpClient();

            var dataString = await _apiClient.GetStringAsync(_remoteServiceBaseUrl);

            var vms = JsonConvert.DeserializeObject<List<VideoViewModel>>(dataString);

            return View(vms);
        }

        [HttpGet]
        public async Task<IActionResult> CreateVideo()
        {
            var vm = new VideoViewModel();
            var genres = await GetAllGenres();

            ViewBag.Genres = genres.ToList();

            return View(vm);
        }

        [HttpGet]
        public async Task<IActionResult> ViewVideo(int id)
        {
            _apiClient = new HttpClient();

            var getVideoUrl = $"{_remoteServiceBaseUrl}/{id}";

            var dataString = await _apiClient.GetStringAsync(getVideoUrl);

            var vm = JsonConvert.DeserializeObject<VideoViewModel>(dataString);

            return View(vm);
        }

        public async Task<List<GenreViewModel>> GetAllGenres()
        {
            _apiClient = new HttpClient();

            var getGenresUrl = "http://192.168.99.100/api/genres/all";

            var dataString = await _apiClient.GetStringAsync(getGenresUrl);

            var genres = JsonConvert.DeserializeObject<List<GenreViewModel>>(dataString);
             
            return genres;
        }

        public async Task<IActionResult> CreateVideo([Bind("Title,Plot,GenreId")]VideoViewModel video)
        {
            _apiClient = new HttpClient();
            
            var createUrl = $"{_remoteServiceBaseUrl}/create";
            
            var contentString = new StringContent(JsonConvert.SerializeObject(video),System.Text.Encoding.UTF8,"application/json");

            var response =  await _apiClient.PostAsync(createUrl,contentString);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> EditVideo(int? id)
        {
            if (id == null)
                return NotFound();
            
            _apiClient = new HttpClient();
            var getVideoUrl = $"{_remoteServiceBaseUrl}/{id}";
            var dataString = await _apiClient.GetStringAsync(getVideoUrl); 
            var video = JsonConvert.DeserializeObject<VideoViewModel>(dataString);

            if (video == null)
                return NotFound();

            var genres = await GetAllGenres();
            ViewBag.Genres = genres.ToList();

            return View(video);
        }

        [HttpPost]
        public async Task<IActionResult> EditVideo(int id,[Bind("Id,Title,Plot")]VideoViewModel video)
        {
            if (ModelState.IsValid)
            {
                _apiClient = new HttpClient();

                var updateUrl = $"{_remoteServiceBaseUrl}/update";

                var contentString = new StringContent(JsonConvert.SerializeObject(video),System.Text.Encoding.UTF8,"application/json");
                
                var response = await _apiClient.PostAsync(updateUrl,contentString);
                
                return RedirectToAction("Index");
            }

            return View(video);
        }

        [HttpGet]
        public async Task<IActionResult> DeleteVideo(int? id)
        {
            if (id == null)
                return NotFound();
            
            _apiClient = new HttpClient();

            var getVideoUrl = $"{_remoteServiceBaseUrl}/{id}";
            
            var dataString = await _apiClient.GetStringAsync(getVideoUrl);

            var vm = JsonConvert.DeserializeObject<VideoViewModel>(dataString);

            if (vm == null)
                return NotFound();
            
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteVideo(int id)
        {
            _apiClient = new HttpClient();

            var deleteUrl = $"{_remoteServiceBaseUrl}/{id}";

            var response = await _apiClient.DeleteAsync(deleteUrl);

            return RedirectToAction("Index");
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
