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
    public class NhomsController : ControllerBase
    {
        private readonly CoreDbContext _context;

        public NhomsController(CoreDbContext context)
        {
            _context = context;
        }

        // GET: api/Nhoms
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Nhom>>> GetNhoms()
        {
            return await _context.Nhoms.ToListAsync();
        }

        // GET: api/Nhoms/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Nhom>> GetNhom(long id)
        {
            var nhom = await _context.Nhoms.FindAsync(id);

            if (nhom == null)
            {
                return NotFound();
            }

            return nhom;
        }

        // PUT: api/Nhoms/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNhom(long id, Nhom nhom)
        {
            if (id != nhom.Id)
            {
                return BadRequest();
            }

            _context.Entry(nhom).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NhomExists(id))
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

        // POST: api/Nhoms
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Nhom>> PostNhom(Nhom nhom)
        {
            _context.Nhoms.Add(nhom);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNhom", new { id = nhom.Id }, nhom);
        }

        // DELETE: api/Nhoms/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Nhom>> DeleteNhom(long id)
        {
            var nhom = await _context.Nhoms.FindAsync(id);
            if (nhom == null)
            {
                return NotFound();
            }

            _context.Nhoms.Remove(nhom);
            await _context.SaveChangesAsync();

            return nhom;
        }

        private bool NhomExists(long id)
        {
            return _context.Nhoms.Any(e => e.Id == id);
        }
    }
}
