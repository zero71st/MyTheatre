using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyTheatreModels;
using MyTheatreApi.Context;

namespace MyTheatreApi.Controllers
{
    [Route("api/[controller]")]
    public class VideoController : Controller
    {
        private VideoContext  db;
        public VideoController()
        {
            db = new VideoContext();
        }
        // GET api/values
        [HttpGet]
        public IEnumerable<Video> Get()
        {
            return db.Videos;
        }

        // GET api/values/5
        [HttpGet("{id:int}")]
        public Video Get(int id)
        {
            return db.Videos.FirstOrDefault(v=> v.Id == id);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
             
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
            
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {

        }
    }
}
