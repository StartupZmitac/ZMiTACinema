using CinemaAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace CinemaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdminController : Controller
    {

        [HttpPost]
        public async Task<IActionResult> addAdmin() { return Ok(); }
        [HttpDelete]
        public async Task<IActionResult> removeAdmin() { return Ok(); }
        [HttpPut]
        public async Task<IActionResult> modifyAdmin() { return Ok(); }
        [HttpGet]
        public async Task<IActionResult> getAllAdmin() { return Ok(); }
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> getAdmin([FromRoute] Guid id) { return Ok(); }


    }
}
