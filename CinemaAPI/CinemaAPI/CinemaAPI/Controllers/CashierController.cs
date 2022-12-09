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
        public async Task<IActionResult> removeCachier() { return Ok(); }
        [HttpPut]
        public async Task<IActionResult> modifyCachier() { return Ok(); }
        [HttpGet]
        public async Task<IActionResult> getAllCachier() { return Ok(); }
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> getCachier([FromRoute] Guid id) { return Ok(); }
    }
}
