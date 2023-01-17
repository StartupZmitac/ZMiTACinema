using CinemaAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CinemaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TicketController : Controller
    {
        private readonly CinemaDbContext _cinemaDbContext;
        public TicketController(CinemaDbContext cinemaDbContext)
        {
            _cinemaDbContext = cinemaDbContext;
        }

        [HttpPost]
        public async Task<IActionResult> addTicket(string screening_id, string seat, string type)
        {
            Ticket newTicket = new Ticket();
            newTicket.Id = Guid.NewGuid();
            newTicket.Type = type;
            newTicket.Seat= seat;
            newTicket.IsChecked = false;
            newTicket.IsPaid = false;
            newTicket.Screening_ID = Guid.Parse(screening_id);

            StatusCodeResult result = changeSeatAvailability(newTicket);

            if (result.Equals(StatusCode(400)))
            {
                return BadRequest();
            }
            else if (result.Equals(StatusCode(404)))
            {
                return NotFound();
            }

            await _cinemaDbContext.Tickets.AddAsync(newTicket);
            await _cinemaDbContext.SaveChangesAsync();
            return (Ok());
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> removeTicket([FromRoute] Guid id)
        {
            var ticket = await _cinemaDbContext.Tickets.FindAsync(id);

            if (ticket == null)
            {
                return NotFound();
            }

            _cinemaDbContext.Tickets.Remove(ticket);

            await _cinemaDbContext.SaveChangesAsync();

            return (Ok(ticket));
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> getTicket([FromRoute] Guid id)
        {
            var ticket = await _cinemaDbContext.Tickets.FindAsync(id);

            return Ok(ticket);
        }

        [HttpGet]
        public async Task<IActionResult> getAllTickets()
        {
            var tickets = await _cinemaDbContext.Tickets.ToListAsync();

            return Ok(tickets);

        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> modifyTicket([FromRoute] Guid id, Ticket ticketRequest)
        {
            var modifyTicket = await _cinemaDbContext.Tickets.FindAsync(id);

            if (modifyTicket == null)
            { return NotFound(); }

            StatusCodeResult result = changeSeatAvailability(ticketRequest);

            if (result.Equals(StatusCode(400)))
            {
                return BadRequest();
            }
            else if (result.Equals(StatusCode(404)))
            {
                return NotFound();
            }

            modifyTicket.Seat = ticketRequest.Seat;
            modifyTicket.IsPaid= ticketRequest.IsPaid;
            modifyTicket.IsChecked= ticketRequest.IsChecked;
            modifyTicket.Type = ticketRequest.Type;
            modifyTicket.Screening_ID = ticketRequest.Screening_ID;

            await _cinemaDbContext.SaveChangesAsync();

            return (Ok(modifyTicket));
        }

        [HttpPut]
        [Route("{id2:Guid}")]
        public async Task<IActionResult> checkTicket([FromRoute] Guid id2, Ticket ticketRequest)
        {
            var modifyTicket = await _cinemaDbContext.Tickets.FindAsync(id2);

            if (modifyTicket == null)
            { return NotFound(); }

            modifyTicket.IsChecked = ticketRequest.IsChecked;

            await _cinemaDbContext.SaveChangesAsync();

            return (Ok(modifyTicket));
        }
        
        private StatusCodeResult changeSeatAvailability(Ticket ticketRequest)
        {
            string ticketSeat = ticketRequest.Seat;
            var connectedScreening = _cinemaDbContext.Screenings.Find(ticketRequest.Screening_ID);

            if (connectedScreening == null)
            {
                return StatusCode(404);
            }

            var connectedRoom = _cinemaDbContext.Rooms.Find(connectedScreening.id_room);

            if (connectedRoom == null)
            {
                return StatusCode(404);
            }

            string[] takenSeats = connectedRoom.taken_seats.Split(",");
            string[] unavailableSeats = connectedRoom.unavailable_seats.Split(",");

            for (int i = 0; i < takenSeats.Length - 1; i++)
            {
                if (ticketSeat.Equals(takenSeats[i]))
                {
                    return StatusCode(400);

                }
            }

            Validator validator = new Validator();
            for (int i = 0; i < unavailableSeats.Length - 1; i++)
            {
                if (ticketSeat.Equals(unavailableSeats[i])|| !validator.checkColumnRowOutOfRange(unavailableSeats[i], connectedRoom.column, connectedRoom.row))
                { 
                    return StatusCode(400);
                }
            }
            return StatusCode(200);
        }
    }
}
