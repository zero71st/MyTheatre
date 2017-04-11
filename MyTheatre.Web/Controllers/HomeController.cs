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
        private HttpClient _apiClient = new HttpClient();
        private readonly string _remoteServiceBaseUrl = "http://192.168.99.100/api/videos";


        [ActionName("Index")]
        public async Task<IActionResult> ListVideosAsync()
        {
            var dataString = await _apiClient.GetStringAsync(_remoteServiceBaseUrl);
            var video = JsonConvert.DeserializeObject<List<VideoViewModel>>(dataString);

            return View(video);
        }

        [HttpGet]
        [ActionName("CreateVideo")]
        public async Task<IActionResult> CreateVideoAsync()
        {
            var video = new VideoViewModel();
            ViewBag.Genres = await GetGenresAsync();

            return View(video);
        }

        [ActionName("ViewVideo")]
        [HttpGet]
        public async Task<IActionResult> ViewVideoAsync(int id)
        {
            var getVideoUrl = $"{_remoteServiceBaseUrl}/{id}";
            var dataString = await _apiClient.GetStringAsync(getVideoUrl);
            var video = JsonConvert.DeserializeObject<VideoViewModel>(dataString);

            return View(video);
        }

        public async Task<List<GenreViewModel>> GetGenresAsync()
        {
            var getGenresUrl = "http://192.168.99.100/api/genres/all";
            var dataString = await _apiClient.GetStringAsync(getGenresUrl);
            var genres = JsonConvert.DeserializeObject<List<GenreViewModel>>(dataString);
             
            return genres;
        }
        
        [HttpPost]
        [ActionName("CreateVideo")]
        public async Task<IActionResult> CreateVideoAsync([Bind("Title,Plot,GenreId")]VideoViewModel video)
        {
         
            if (ModelState.IsValid)
            {
                var createUrl = $"{_remoteServiceBaseUrl}/create";
                var contentString = new StringContent(JsonConvert.SerializeObject(video), System.Text.Encoding.UTF8, "application/json");
                var response = await _apiClient.PostAsync(createUrl, contentString);

                return RedirectToAction("Index");
            }

            ViewBag.Genres = await GetGenresAsync();

            return View(video);
        }

        [HttpGet]
        [ActionName("EditVideo")]
        public async Task<IActionResult> EditVideoAsync(int? id)
        {
            if (id == null)
                return NotFound();
            
            var getVideoUrl = $"{_remoteServiceBaseUrl}/{id}";
            var dataString = await _apiClient.GetStringAsync(getVideoUrl); 
            var video = JsonConvert.DeserializeObject<VideoViewModel>(dataString);

            if (video == null)
                return NotFound();

            ViewBag.Genres = await GetGenresAsync();

            return View(video);
        }

        [HttpPost]
        [ActionName("EditVideo")]
        public async Task<IActionResult> EditVideoAsync(int id,[Bind("Id,Title,Plot,GenreId")]VideoViewModel video)
        {
            if (ModelState.IsValid)
            {
                var updateUrl = $"{_remoteServiceBaseUrl}/update";
                var contentString = new StringContent(JsonConvert.SerializeObject(video),System.Text.Encoding.UTF8,"application/json");
                var response = await _apiClient.PostAsync(updateUrl,contentString);
                
                return RedirectToAction("Index");
            }

            ViewBag.Genres = await GetGenresAsync();

            return View(video);
        }

        [HttpGet]
        [ActionName("DeleteVideo")]
        public async Task<IActionResult> DeleteVideoAsync(int? id)
        {
            if (id == null)
                return NotFound();
            
            var getVideoUrl = $"{_remoteServiceBaseUrl}/{id}";
            var dataString = await _apiClient.GetStringAsync(getVideoUrl);
            var video = JsonConvert.DeserializeObject<VideoViewModel>(dataString);

            if (video == null)
                return NotFound();
            
            return View(video);
        }

        [HttpPost]
        [ActionName("DeleteVideo")]
        public async Task<IActionResult> DeleteVideoAsync(int id)
        {
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
