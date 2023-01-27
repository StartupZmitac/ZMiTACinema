using CinemaAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections;

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
        public async Task<IActionResult> addTicket([FromBody] Ticket ticket)
        {
            Ticket newTicket = ticket;
            newTicket.Id = Guid.NewGuid();
            bool result = changeSeatAvailability(newTicket).Result;

            if (result == false)
            {
                 return BadRequest();
            }

            newTicket.IsChecked = false;
            newTicket.IsPaid = false;
            await _cinemaDbContext.Tickets.AddAsync(newTicket);
            await _cinemaDbContext.SaveChangesAsync();
            return (Ok());
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> removeTicket([FromRoute] string id)
        {
            var tickets = await _cinemaDbContext.Tickets.Where(x => x.Transaction_ID == id).ToListAsync();

            if (tickets == null)
            {
                return NotFound();
            }

            var connectedScreening = await _cinemaDbContext.Screenings.FindAsync(tickets[0].Screening_ID);
            var connectedRoom = await _cinemaDbContext.Rooms.FindAsync(connectedScreening.id_room);
            ArrayList takenSeats = new ArrayList();
            takenSeats.AddRange(connectedRoom.taken_seats.Split(",", StringSplitOptions.RemoveEmptyEntries));
            string ticketSeat = "";
            foreach (var ticket in tickets)
            {
                ticketSeat = ticket.Seat;
                takenSeats.Remove(ticketSeat);
                _cinemaDbContext.Tickets.Remove(ticket);
            }
            string temp = "";
            for (int i = 0; i < takenSeats.Count; i++) 
            {
                temp += (string)takenSeats[i] + ",";
            }
            connectedRoom.taken_seats = temp;
            await _cinemaDbContext.SaveChangesAsync();
            return (Ok(tickets));
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
            { 
                return NotFound(); 
            }

            bool result = changeSeatAvailability(ticketRequest).Result;

            if (result == false)
            {
                return BadRequest();
            }

            modifyTicket.Seat = ticketRequest.Seat;
            modifyTicket.IsPaid= ticketRequest.IsPaid;
            modifyTicket.IsChecked= ticketRequest.IsChecked;
            modifyTicket.Type = ticketRequest.Type;
            modifyTicket.Screening_ID = ticketRequest.Screening_ID;
            modifyTicket.Transaction_ID = ticketRequest.Transaction_ID;

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
        
        private async Task<bool> changeSeatAvailability(Ticket ticketRequest)
        {
            string ticketSeat = ticketRequest.Seat;
            var connectedScreening = await _cinemaDbContext.Screenings.FindAsync(ticketRequest.Screening_ID);

            if (connectedScreening == null)
            {
                return false;
            }

            var connectedRoom = await _cinemaDbContext.Rooms.FindAsync(connectedScreening.id_room);

            if (connectedRoom == null)
            {
                return false;
            }

            string[] takenSeats = connectedRoom.taken_seats.Split(",", StringSplitOptions.RemoveEmptyEntries);
            string[] unavailableSeats = connectedRoom.unavailable_seats.Split(",", StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < takenSeats.Length - 1; i++)
            {
                if (ticketSeat.Equals(takenSeats[i]))
                {
                    return false;
                }
            }

            Validator validator = new Validator();
            for (int i = 0; i < unavailableSeats.Length - 1; i++)
            {
                if (ticketSeat.Equals(unavailableSeats[i]) || !validator.checkColumnRowOutOfRange(unavailableSeats[i], connectedRoom.column, connectedRoom.row))
                { 
                    return false;
                }
            }
            connectedRoom.taken_seats = connectedRoom.taken_seats + ticketSeat + ",";
            await _cinemaDbContext.SaveChangesAsync();
            return true;
        }
    }
}
