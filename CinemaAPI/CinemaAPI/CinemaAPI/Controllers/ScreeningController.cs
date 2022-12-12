using CinemaAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CinemaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ScreeningController : Controller
    {
        private readonly CinemaDbContext cinemaDbContext;
        public ScreeningController(CinemaDbContext cinemaDbContext)
        {
            this.cinemaDbContext = cinemaDbContext;
        }
        [HttpPost]
        public async Task<IActionResult> AddScreening([FromBody] Screening screeningRequest)
        {
            screeningRequest.Screening_ID = Guid.NewGuid();
            await cinemaDbContext.AddAsync(screeningRequest);
            await cinemaDbContext.SaveChangesAsync();
            return Ok(screeningRequest);
        }
        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> modifyScreening([FromRoute] Guid id, Screening screeningRequest)
        {
            var toModify = await cinemaDbContext.Screenings.FindAsync(id);
            if (toModify == null)
            {
                return NotFound();
            }
            toModify.Film = screeningRequest.Film;
            toModify.Room = screeningRequest.Room;
            toModify.Time= screeningRequest.Time;
            toModify.id_room = screeningRequest.id_room;
            toModify.Id_Film = screeningRequest.Id_Film;
            await cinemaDbContext.SaveChangesAsync();
            return Ok(screeningRequest);
        }
        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> removeScreening([FromRoute] Guid id)
        {
            var toDelete = await cinemaDbContext.Screenings.FindAsync(id);
            if (toDelete == null)
            {
                return NotFound();
            }
            cinemaDbContext.Screenings.Remove(toDelete);
            await cinemaDbContext.SaveChangesAsync();
            return Ok(toDelete);
        }
        [HttpGet]
        public async Task<IActionResult> getAllScreenings(string location, DateTime date)
        {
            var screenings = await cinemaDbContext.Screenings.Where(x => x.Time == date && x.Location== location).ToListAsync();
            return Ok(screenings);
        }
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> getScreening([FromRoute] Guid id)
        {
            var screening = await cinemaDbContext.Screenings.FindAsync(id);
            if (screening == null)
            {
                return NotFound();
            }
            return Ok(screening);
        }
    }
}
