using CinemaAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CinemaAPI.Controllers
{
    [ApiController]
    [Route("api[controller]")]
    public class RoomController : Controller
    {
        private readonly CinemaDbContext _cinemaDbContext;
        public RoomController(CinemaDbContext cinemaDbContext)
        {
            _cinemaDbContext = cinemaDbContext;
        }

        [HttpPost]
        public async Task<IActionResult> addRoom([FromBody] Room roomRequest)
        {
            roomRequest.id_room = Guid.NewGuid();

            await _cinemaDbContext.Rooms.AddAsync(roomRequest);

            await _cinemaDbContext.SaveChangesAsync();

            return (Ok());
        }
        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> removeRoom([FromRoute] Guid id)
        {
            var room = await _cinemaDbContext.Rooms.FindAsync(id);

            if (room == null)
            {
                return NotFound();
            }

            _cinemaDbContext.Rooms.Remove(room);

            await _cinemaDbContext.SaveChangesAsync();

            return (Ok(room));
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> getRoom([FromRoute] Guid id) 
        {
            var room = await _cinemaDbContext.Rooms.FindAsync(id);

            return Ok(room);
        }

        [HttpGet]
        public async Task<IActionResult> getAllRooms()
        {
            var rooms = await _cinemaDbContext.Rooms.ToListAsync();

            return Ok(rooms);

        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> modifyRoom([FromRoute] Guid id, Room roomRequest)
        {
            var modifyRoom = await _cinemaDbContext.Rooms.FindAsync(id);

            if (modifyRoom == null)
            { return NotFound(); }

            modifyRoom.column = roomRequest.column;
            modifyRoom.row = roomRequest.row;
            modifyRoom.taken_seats= roomRequest.taken_seats;
            modifyRoom.unavailable_seats= roomRequest.unavailable_seats;
            modifyRoom.id_location= roomRequest.id_location;

            await _cinemaDbContext.SaveChangesAsync();

            return (Ok(modifyRoom));
        }


    }
}
