using CinemaAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CinemaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FilmController : Controller
    {
        private readonly CinemaDbContext cinemaDbContext;

        public FilmController(CinemaDbContext cinemaDbContext)
        {
            this.cinemaDbContext = cinemaDbContext;
        }
        [HttpPost]
        public async Task<IActionResult> AddFilm([FromBody] Film filmRequest)
        {
            filmRequest.Id_Film = Guid.NewGuid();
            await cinemaDbContext.AddAsync(filmRequest);
            await cinemaDbContext.SaveChangesAsync();
            return Ok(filmRequest);
        }
        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> modifyFilm([FromRoute] Guid id ,Film filmRequest)
        {
            var toModify = await cinemaDbContext.Films.FindAsync(id);
            if (toModify == null)
            {
                return NotFound();
            }
            toModify.Is3D = filmRequest.Is3D;
            toModify.Age = filmRequest.Age;
            toModify.Category = filmRequest.Category;
            toModify.Dubbing = filmRequest.Dubbing;
            toModify.ImageSource = filmRequest.ImageSource;
            toModify.Language= filmRequest.Language;
            toModify.Name = filmRequest.Name;
            toModify.Sub = filmRequest.Sub;
            toModify.Time = filmRequest.Time;
            await cinemaDbContext.SaveChangesAsync();
            return Ok(filmRequest);
        }
        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> removeFilm([FromRoute] Guid id)
        {
            var toDelete = await cinemaDbContext.Films.FindAsync(id);
            if (toDelete == null)
            {
                return NotFound();
            }
            cinemaDbContext.Films.Remove(toDelete);
            await cinemaDbContext.SaveChangesAsync();
            return Ok(toDelete);
        }
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> getFilm([FromRoute] Guid id)
        {
            var film = await cinemaDbContext.Films.FindAsync(id);
            if (film == null)
            {
                return NotFound();
            }
            return Ok(film);
        }
    }
}
