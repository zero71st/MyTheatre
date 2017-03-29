using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyTheatre.Domain;
using MyTheatre.Api.Infrastructure;

namespace MyTheatre.Api.Controllers
{
    [Route("api/[controller]")]
    public class videosController : Controller
    {
        private MyTheatreContext  _db;
        public videosController(MyTheatreContext db)
        {
            _db = db;
        }
        // GET api/Video
        [HttpGet]
        public IEnumerable<Video> Videos()
        {
            return _db.Videos;
        }

        // GET api/Video/5
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetVideo(int id)
        {
            var video = await _db.Videos.FindAsync(id);
            if (video == null)
                return NotFound();
                
            return Ok(video);
        }

        // POST api/Video]
        [Route("create")]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody]Video video)
        {
                _db.Videos.Add(
                    new Video 
                    {
                        Title = video.Title,
                        Plot = video.Plot
                    });
               await _db.SaveChangesAsync();
               return Ok();
        }

        // PUT api/video/5
        [Route("update")]
        [HttpPost]
        public async Task<IActionResult> UpdateVideo([FromBody]Video video)
        {
            var videoToUpdate =  await _db.Videos.FindAsync(video.Id);
            if (videoToUpdate == null)
                return NotFound();

            videoToUpdate.Title = video.Title;
            videoToUpdate.Plot = video.Plot;

            _db.Videos.Update(videoToUpdate);

            await _db.SaveChangesAsync();

            return Ok();
        }

        // DELETE api/video/5
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteVideo(int id)
        {
            var videoToDelete = await _db.Videos.FindAsync(id);

            if (videoToDelete == null)
                return NotFound();

             _db.Videos.Remove(videoToDelete);
             await _db.SaveChangesAsync();

             return Ok();
        }
    }
}
