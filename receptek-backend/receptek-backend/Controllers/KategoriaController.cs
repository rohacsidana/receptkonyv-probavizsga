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
    [EnableCors]
    [Route("api/kategoria")]
    [ApiController]
    public class KategoriaController : ControllerBase
    {
        ReceptContext _context;

        public KategoriaController(ReceptContext context)
        {
            _context = context;
        }

        [EnableCors]
        [HttpGet]
        public async Task<ActionResult<List<Kategoriak>>> Get()
        {
            var kategoriak = await _context.Kategoriaks.ToListAsync();
            if (kategoriak.IsNullOrEmpty())
                return BadRequest("Nincs kategória;");
            return Ok(kategoriak);
        }

        //[HttpGet("list")]
        //public IActionResult KategoriaList()
        //{
        //    try
        //    {
        //        var ldList = _context.Kategoriaks.ToList();
        //        if (ldList.Count() == 0)
        //        {
        //            return NotFound("Kategoria not found");
        //        }
        //        return Ok(ldList);
        //    }
        //    catch (Exception)
        //    {
        //        return BadRequest();
        //    }
        //}


    }
}
