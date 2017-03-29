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
        public IEnumerable<Video> Get()
        {
            // return _db.Videos;
            return null;
        }

        // GET api/Video/5
        [HttpGet("{id:int}")]
        public Video Get(int id)
        {
            // return _db.Videos.FirstOrDefault(v=> v.Id == id);
            return null;
        }

        // POST api/Video
        [HttpPost]
        public void Post([FromBody]Video video)
        {
            //  _db.Videos.Add(video);
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
