using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using receptek_backend.Models;
using System.Data;

namespace receptek_backend.Controllers
{
    [Route("api/recept")]
    [ApiController]
    public class ReceptController : ControllerBase
    {
        ReceptContext _context;

        public ReceptController(ReceptContext context)
        {
            _context = context;
        }

        [EnableCors]
        [HttpGet]
        public async Task<ActionResult<List<Receptek>>> Get()
        {

            var receptek = await _context.Recepteks.Include(x => x.Kat).ToListAsync();
            if (receptek.IsNullOrEmpty())
                return BadRequest("Nincs recept");
            return Ok(receptek);
        }
        [EnableCors]
        [HttpPost]
        public async Task<ActionResult<List<Receptek>>> AddRecept(Receptek recept)
        {
            _context.Recepteks.AddAsync(recept);
            _context.SaveChangesAsync();
            return Ok(await _context.Recepteks.Include(x => x.Kat).ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var recept = await _context.Recepteks.FindAsync(id);
            if (recept == null)
                return BadRequest("Nem létezik az adott recept.");
            _context.Recepteks.Remove(recept);
            await _context.SaveChangesAsync();
            return Ok("Siker");
        }

       
    }
}