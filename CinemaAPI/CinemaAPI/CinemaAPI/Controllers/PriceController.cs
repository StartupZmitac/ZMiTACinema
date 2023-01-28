using CinemaAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CinemaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PriceController : Controller
    {
        private readonly CinemaDbContext _cinemaDbContext;
        public PriceController(CinemaDbContext cinemaDbContext)
        {
            _cinemaDbContext = cinemaDbContext;
        }

        [HttpPost]
        public async Task<IActionResult> addPrice([FromBody] Price priceRequest)
        {
            priceRequest.Id = Guid.NewGuid();
            await _cinemaDbContext.AddAsync(priceRequest);
            await _cinemaDbContext.SaveChangesAsync();
            return Ok();
        }
        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> removePrice([FromRoute] Guid id)
        {
            var toDelete = await _cinemaDbContext.Prices.FindAsync(id);
            if (toDelete == null)
            {
                return NotFound();
            }
            _cinemaDbContext.Prices.Remove(toDelete);
            await _cinemaDbContext.SaveChangesAsync();
            return Ok(toDelete);
        }
        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> modifyPrice([FromRoute] Guid id, Price priceRequest)
        {
            var toModify = await _cinemaDbContext.Prices.FindAsync(id);
            if (toModify == null)
            {
                return NotFound();
            }
            toModify.Cost = priceRequest.Cost;
            toModify.Type = priceRequest.Type;
            await _cinemaDbContext.SaveChangesAsync();
            return Ok();
        }
        [HttpGet]
        public async Task<IActionResult> getAllPrices()
        {
            var prices = await _cinemaDbContext.Prices.ToListAsync();

            return Ok(prices);
        }
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> getPrice([FromRoute] Guid id)
        {
            var prices = await _cinemaDbContext.Prices.FindAsync(id);
            if (prices == null)
            {
                return NotFound();
            }
            return Ok(prices);
        }
    }
}
