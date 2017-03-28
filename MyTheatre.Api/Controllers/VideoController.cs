using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyTheatre.Domain;
using MyTheatreApi.Context;

namespace MyTheatreApi.Controllers
{
    [Route("api/[controller]")]
    public class VideoController : Controller
    {
        private VideoContext  _db;
        public VideoController()
        {
            _db = new VideoContext();
        }
        // GET api/Video
        [HttpGet]
        public IEnumerable<Video> Get()
        {
            return _db.Videos;
        }

        // GET api/Video/5
        [HttpGet("{id:int}")]
        public Video Get(int id)
        {
            return _db.Videos.FirstOrDefault(v=> v.Id == id);
        }

        // POST api/Video
        [HttpPost]
        public void Post([FromBody]Video video)
        {
             _db.Videos.Add(video);
        }

        // PUT api/Video/5
        [HttpPut("{id:int}")]
        public void Put(int id, [FromBody]Video video)
        {
            
        }

        // DELETE api/video/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {

        }
    }
}
