using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Doan5Auto.Models;

namespace Doan5Auto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoaisanphamsController : ControllerBase
    {
        private readonly CoreDbContext _context;

        public LoaisanphamsController(CoreDbContext context)
        {
            _context = context;
        }

        // GET: api/Loaisanphams
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Loaisanpham>>> GetLoaisanphams()
        {
            return await _context.Loaisanphams.ToListAsync();
        }

        // GET: api/Loaisanphams/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Loaisanpham>> GetLoaisanpham(long id)
        {
            var loaisanpham = await _context.Loaisanphams.FindAsync(id);

            if (loaisanpham == null)
            {
                return NotFound();
            }

            return loaisanpham;
        }

        // PUT: api/Loaisanphams/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLoaisanpham(int id, Loaisanpham loaisanpham)
        {
            if (id != loaisanpham.Id)
            {
                return BadRequest();
            }

            _context.Entry(loaisanpham).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LoaisanphamExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Loaisanphams
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Loaisanpham>> PostLoaisanpham(Loaisanpham loaisanpham)
        {
            _context.Loaisanphams.Add(loaisanpham);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLoaisanpham", new { id = loaisanpham.Id }, loaisanpham);
        }

        // DELETE: api/Loaisanphams/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Loaisanpham>> DeleteLoaisanpham(long id)
        {
            var loaisanpham = await _context.Loaisanphams.FindAsync(id);
            if (loaisanpham == null)
            {
                return NotFound();
            }

            _context.Loaisanphams.Remove(loaisanpham);
            await _context.SaveChangesAsync();

            return loaisanpham;
        }

        private bool LoaisanphamExists(int id)
        {
            return _context.Loaisanphams.Any(e => e.Id == id);
        }
    }
}
