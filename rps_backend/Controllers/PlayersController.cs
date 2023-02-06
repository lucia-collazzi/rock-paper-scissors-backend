using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using rps_backend.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace rps_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayersController : ControllerBase
    {
        private readonly AplicationDbContext _context;
        public PlayersController(AplicationDbContext context) 
        {
            _context = context;
        }

        // GET: api/<PlayersController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var playersList = await _context.Players.ToListAsync();
                return Ok(playersList);
            }
            catch (Exception ex)
            {
               return BadRequest(ex.Message);
            }
        }

        // GET api/<PlayersController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult>  Get(int id)
        {
            try
            {               
                var player = await _context.Players.FindAsync(id);

                if( player == null)
                {
                    return NotFound();
                }
                    return Ok(player);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // POST api/<MovesController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Player player)
        {
            try
            {
                _context.Add(player);
                await _context.SaveChangesAsync();
                return Ok(player);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<PlayersController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Player player)
        {
            try
            {
                if (id != player.Id)
                {
                    return NotFound();
                }
                
                _context.Update(player);
                await _context.SaveChangesAsync();
                return Ok(new { message = "The player has been updated successfully" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        // DELETE api/<MovesController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var player = await _context.Players.FindAsync(id);
                if (player == null)
                {
                    return NotFound();
                }
                _context.Players.Remove(player);
                await _context.SaveChangesAsync();
                return Ok(new { message = "The player was deleted successfully" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
