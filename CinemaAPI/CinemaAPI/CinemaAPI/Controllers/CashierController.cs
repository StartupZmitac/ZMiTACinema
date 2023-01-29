using CinemaAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CinemaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CashierController : Controller
    {
        private readonly CinemaDbContext cinemaDbContext;

        public CashierController(CinemaDbContext cinemaDbContext)
        {
            this.cinemaDbContext = cinemaDbContext;
        }
        [HttpPost]
        public async Task<IActionResult> addCashier([FromBody] Cashier cashierRequest) 
        { 
            cashierRequest.Id = Guid.NewGuid();
            await cinemaDbContext.AddAsync(cashierRequest);
            await cinemaDbContext.SaveChangesAsync();
            return Ok();
        }
        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> removeCashier([FromRoute] Guid id) 
        {
            var toDelete = await cinemaDbContext.Cashiers.FindAsync(id);
            if (toDelete == null)
            {
                return NotFound();
            }
            cinemaDbContext.Cashiers.Remove(toDelete);
            await cinemaDbContext.SaveChangesAsync();
            return Ok(toDelete); 
        }
        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> modifyCashier([FromRoute] Guid id, Cashier cashierRequest) 
        {
            var toModify = await cinemaDbContext.Cashiers.FindAsync(id);
            if (toModify == null)
            {
                return NotFound();
            }
            toModify.password = cashierRequest.password;
            toModify.login = cashierRequest.login;
            await cinemaDbContext.SaveChangesAsync();
            return Ok(); 
        }
        [HttpGet]
        public async Task<IActionResult> getAllCashier() 
        {
            var cashiers = await cinemaDbContext.Cashiers.ToListAsync();

            return Ok(cashiers);
        }
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> getCashier([FromRoute] Guid id) 
        {
            var cashier = await cinemaDbContext.Cashiers.FindAsync(id);
            if (cashier == null)
            {
                return NotFound();
            }
            return Ok(cashier);
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> loginCashier([FromBody] Cashier cashierRequest)
        {
            var cashier = await cinemaDbContext.Cashiers.SingleOrDefaultAsync(x => x.login == cashierRequest.login && x.password == cashierRequest.password);
            if (cashier == null)
            {
                return NotFound();
            }
            return Ok(cashier);
        }
    }
}
