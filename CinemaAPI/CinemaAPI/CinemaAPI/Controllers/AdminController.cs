using CinemaAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CinemaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdminController : Controller
    {
        private readonly CinemaDbContext cinemaDbContext;

        public AdminController(CinemaDbContext cinemaDbContext)
        {
            this.cinemaDbContext = cinemaDbContext;
        }

        [HttpPost]
        public async Task<IActionResult> addAdmin([FromBody] Admin adminRequest) 
        {
            adminRequest.Id = Guid.NewGuid();
            await cinemaDbContext.AddAsync(adminRequest);
            await cinemaDbContext.SaveChangesAsync();
            return Ok(); 
        }
        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> removeAdmin([FromRoute] Guid id) 
        {
            var toDelete = await cinemaDbContext.Admins.FindAsync(id);
            if (toDelete == null)
            {
                return NotFound();
            }
            cinemaDbContext.Admins.Remove(toDelete);
            await cinemaDbContext.SaveChangesAsync();
            return Ok(toDelete);
        }
        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> modifyAdmin([FromRoute] Guid id, Admin adminRequest) 
        {
            var toModify = await cinemaDbContext.Admins.FindAsync(id);
            if (toModify == null)
            {
                return NotFound();
            }
            toModify.password = adminRequest.password;
            toModify.login = adminRequest.login;
            await cinemaDbContext.SaveChangesAsync();
            return Ok();
        }
        [HttpGet]
        public async Task<IActionResult> getAllAdmin() 
        {
            var admins = await cinemaDbContext.Admins.ToListAsync();

            return Ok(admins);
        }
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> getAdmin([FromRoute] Guid id) 
        {
            var admin = await cinemaDbContext.Admins.FindAsync(id);
            if (admin == null)
            {
                return NotFound();
            }
            return Ok(admin);
        }
    }
}
