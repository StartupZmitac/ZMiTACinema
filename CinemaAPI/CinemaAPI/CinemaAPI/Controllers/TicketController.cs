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
            bool result = changeSeatAvailability(newTicket);
            
            if (result == false)
            {
                 return BadRequest();
            }
            var connectedScreening = await _cinemaDbContext.Screenings.FindAsync(newTicket.Screening_ID);
            var connectedRoom = await _cinemaDbContext.Rooms.FindAsync(connectedScreening.id_room);
            connectedRoom.taken_seats = connectedRoom.taken_seats + newTicket.Seat + ",";
            newTicket.IsChecked = false;
            var connectedPrice = await _cinemaDbContext.Prices.Where(x=>x.Type==ticket.Type).ToListAsync();
            newTicket.Price_ID = connectedPrice[0].Id;
            newTicket._price = connectedPrice[0];
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
        [Route("transaction")]
        public async Task<IActionResult> getTicket(string transactionId)
        {
            var ticket = await _cinemaDbContext.Tickets.Where(x => x.Transaction_ID == transactionId).ToListAsync();

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

            bool result = changeSeatAvailability(ticketRequest);

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
            modifyTicket.Price_ID = ticketRequest.Price_ID;
            var connectedScreening = await _cinemaDbContext.Screenings.FindAsync(modifyTicket.Screening_ID);
            var connectedRoom = await _cinemaDbContext.Rooms.FindAsync(connectedScreening.id_room);
            connectedRoom.taken_seats = connectedRoom.taken_seats + modifyTicket.Seat + ",";

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
        
        private bool changeSeatAvailability(Ticket ticketRequest)
        {
            string ticketSeat = ticketRequest.Seat;

            var connectedScreening = _cinemaDbContext.Screenings.Find(ticketRequest.Screening_ID);

            if (connectedScreening == null)
            {
                return false;
            }

            var connectedRoom = _cinemaDbContext.Rooms.Find(connectedScreening.id_room);

            if (connectedRoom == null)
            {
                return false;
            }

            Validator validator = new Validator();
            if (validator.checkColumnRowOutOfRange(ticketSeat, connectedRoom.column, connectedRoom.row) == false /*|| validator.checkTime(connectedScreening.Time) == false*/)
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

            for (int i = 0; i < unavailableSeats.Length - 1; i++)
            {
                if (ticketSeat.Equals(unavailableSeats[i]))
                { 
                    return false;
                }
            }

            return true;
        }
    }
}
