using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportApp.Data;
using SportApp.Models;

namespace SportApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SportController : ControllerBase
    {
        private readonly SportContext _context;

        public SportController(SportContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<Event>>> getSportEvents()
        {
            List<Event> events = await _context.Events.ToListAsync();
            return Ok(events);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Event>> getSportEvent(int id)
        {
            Event? oneEvent = await _context.Events.FindAsync(id);
            if (oneEvent == null)
            {
                return NotFound();
            }
            return Ok(oneEvent);
        }
        [HttpPost]
        public async Task<ActionResult<Event>> postSportEvent([FromBody] Event ev)
        {
            int maxId = await _context.Events.MaxAsync(ev => ev.Id);
            await _context.Events.AddAsync(ev);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
