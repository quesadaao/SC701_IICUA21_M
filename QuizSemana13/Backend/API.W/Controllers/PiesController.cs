using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.W.Models;

namespace API.W.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PiesController : ControllerBase
    {
        private readonly FidelitasContext _context;

        public PiesController(FidelitasContext context)
        {
            _context = context;
        }

        // GET: api/Pies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pies>>> GetPies()
        {
            return await _context.Pies.ToListAsync();
        }

        // GET: api/Pies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Pies>> GetPies(int id)
        {
            var pies = await _context.Pies.FindAsync(id);

            if (pies == null)
            {
                return NotFound();
            }

            return pies;
        }

        // PUT: api/Pies/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPies(int id, Pies pies)
        {
            if (id != pies.Id)
            {
                return BadRequest();
            }

            _context.Entry(pies).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PiesExists(id))
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

        // POST: api/Pies
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Pies>> PostPies(Pies pies)
        {
            _context.Pies.Add(pies);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPies", new { id = pies.Id }, pies);
        }

        // DELETE: api/Pies/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Pies>> DeletePies(int id)
        {
            var pies = await _context.Pies.FindAsync(id);
            if (pies == null)
            {
                return NotFound();
            }

            _context.Pies.Remove(pies);
            await _context.SaveChangesAsync();

            return pies;
        }

        private bool PiesExists(int id)
        {
            return _context.Pies.Any(e => e.Id == id);
        }
    }
}
