using Microsoft.AspNetCore.Mvc;

namespace CinemaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CashierController : Controller
    {
        [HttpPost]
        public async Task<IActionResult> addCashier() { return Ok(); }
        [HttpDelete]
        public async Task<IActionResult> removeCashier() { return Ok(); }
        [HttpPut]
        public async Task<IActionResult> modifyCashier() { return Ok(); }
        [HttpGet]
        public async Task<IActionResult> getAllCashier() { return Ok(); }
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> getCashier([FromRoute] Guid id) { return Ok(); }
    }
}
