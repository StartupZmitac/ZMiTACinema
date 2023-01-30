using CinemaAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CinemaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LocationController : Controller
    {
        private readonly CinemaDbContext _cinemaDbContext;
        public LocationController(CinemaDbContext cinemaDbContext) 
        {
            _cinemaDbContext = cinemaDbContext;        
        }

        [HttpPost]
        public async Task<IActionResult> addLocation([FromBody] Location locationRequest) 
        {
            locationRequest.id_location = Guid.NewGuid();

            await _cinemaDbContext.Locations.AddAsync(locationRequest);  

            await _cinemaDbContext.SaveChangesAsync();

            return(Ok());
        }
        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> removeLocation([FromRoute] Guid id) 
        {
            var location = await _cinemaDbContext.Locations.FindAsync(id);

            if(location == null) 
            {
                return NotFound();
            }

            _cinemaDbContext.Locations.Remove(location);

            await _cinemaDbContext.SaveChangesAsync();

            return(Ok(location));
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> getLocation([FromRoute] Guid id)
        {
            var location = await _cinemaDbContext.Locations.FindAsync(id);

            return Ok(location);
        }
        [HttpGet]
        [Route("by-name")]
        public async Task<IActionResult> getLocation(string name)
        {
            var location = await _cinemaDbContext.Locations.SingleOrDefaultAsync(x => x.city == name);

            return Ok(location);
        }

        [HttpGet]
        public async Task<IActionResult> getAllLocations() 
        {
            var locations = await _cinemaDbContext.Locations.ToListAsync();

            return Ok(locations);

        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> modifyLocation([FromRoute] Guid id, Location locationRequest) 
        {
            var modifyLocation = await _cinemaDbContext.Locations.FindAsync(id);

            if(modifyLocation == null)
            { return NotFound(); }

            modifyLocation.city = locationRequest.city;

            await _cinemaDbContext.SaveChangesAsync();

            return(Ok(modifyLocation));

        }
    }
}
