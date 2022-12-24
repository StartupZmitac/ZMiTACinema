﻿using CinemaAPI.Models;
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
        public async Task<IActionResult> addTicket([FromBody] Ticket ticketRequest)
        {
            ticketRequest.Id = Guid.NewGuid();

            await _cinemaDbContext.Tickets.AddAsync(ticketRequest);

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

            modifyTicket.Time = ticketRequest.Time;
            modifyTicket.Seat = ticketRequest.Seat;
            modifyTicket.Room = ticketRequest.Room;
            modifyTicket.IsPaid= ticketRequest.IsPaid;
            modifyTicket.IsChecked= ticketRequest.IsChecked;
            modifyTicket.Film = ticketRequest.Film;
            modifyTicket.Type = ticketRequest.Type;
            modifyTicket.id_room = ticketRequest.id_room;

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

        [HttpPut]
        public async Task<IActionResult> changeSeatAvailability()
        {
            return Ok();
        }
    }
}
