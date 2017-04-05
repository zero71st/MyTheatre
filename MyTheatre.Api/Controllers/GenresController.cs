
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyTheatre.Api.Infrastructure;
using MyTheatre.Domain;

namespace MyTheatre.Api.Controllers
{
    [Route("api/[controller]")]
    public class genresController : Controller
    {
        private MyTheatreContext _db;

        public genresController(MyTheatreContext db)
        {
            _db = db;
        }

        [Route("genres")]
        [HttpGet]
        public async Task<List<Genre>> GetGenres()
        {
            List<Genre> genres = await _db.Genres.ToListAsync();

            return genres;
        }

        [Route("create")]
        [HttpPost]
        public async Task<IActionResult> CreateGenre([FromBody]Genre genre)
        {
            if (genre == null)
                return NotFound();
            
            Genre genreToAdd = new Genre { Name = genre.Name};

            _db.Genres.Add(genreToAdd);

            await _db.SaveChangesAsync();

            return Ok();
        }

        [Route("update")]
        [HttpPost]
        public async Task<IActionResult> UpdateGenre([FromBody]Genre genre)
        {
            if (genre == null)
                return NotFound();
            
            Genre genreToUpdate = await _db.Genres.FindAsync(genre.Id);

            if (genreToUpdate == null)
                return NotFound();
            
            genreToUpdate.Name = genre.Name;

            _db.Genres.Update(genreToUpdate);

            await _db.SaveChangesAsync();

            return Ok();

        }
    }
}