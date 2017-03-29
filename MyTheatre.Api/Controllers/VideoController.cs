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
    public class VideoController : Controller
    {
        private MyTheatreContext  _db;
        public VideoController(MyTheatreContext db)
        {
            _db = db;
        }
        // GET api/Video
        [HttpGet]
        public dynamic Get()
        {
            return _db.Videos.Select(t=> new {Id = t.Id,Title = t.Title,Plot = t.Plot});
        }

        // GET api/Video/5
        [HttpGet("{id:int}")]
        public Video Get(int id)
        {
            return _db.Videos.FirstOrDefault(t=> t.Id == id);
        }

        // POST api/Video]
        [HttpPost]
        public void Post([FromBody]Video video)
        {
            if (video != null)
            {
                _db.Videos.Add(video);
                _db.SaveChanges();
            }
        }

        // PUT api/video/5
        [HttpPut("{id:int}")]
        public void Put(int id, [FromBody]Video video)
        {
            var v = _db.Videos.Find(id);

            if (v != null)
            {
                v.Title = video.Title;
                v.Plot = video.Plot;
                _db.Videos.Add(v);
                _db.SaveChanges();
            }
        }

        // DELETE api/video/5
        [HttpDelete("{id:int}")]
        public void Delete(int id)
        {
            var v = _db.Videos.Find(id);

            if (v != null)
            {
                _db.Videos.Remove(v);
                _db.SaveChanges();
            }
            
        }
    }
}
