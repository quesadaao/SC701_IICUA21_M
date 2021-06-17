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
    public class GroupUpdatesController : ControllerBase
    {
        private readonly SocialGoalContext _context;

        public GroupUpdatesController(SocialGoalContext context)
        {
            _context = context;
        }

        // GET: api/GroupUpdates
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GroupUpdates>>> GetGroupUpdates()
        {
            return await _context.GroupUpdates.ToListAsync();
        }

        // GET: api/GroupUpdates/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GroupUpdates>> GetGroupUpdates(int id)
        {
            var groupUpdates = await _context.GroupUpdates.FindAsync(id);

            if (groupUpdates == null)
            {
                return NotFound();
            }

            return groupUpdates;
        }

        // PUT: api/GroupUpdates/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGroupUpdates(int id, GroupUpdates groupUpdates)
        {
            if (id != groupUpdates.GroupUpdateId)
            {
                return BadRequest();
            }

            _context.Entry(groupUpdates).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GroupUpdatesExists(id))
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

        // POST: api/GroupUpdates
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<GroupUpdates>> PostGroupUpdates(GroupUpdates groupUpdates)
        {
            _context.GroupUpdates.Add(groupUpdates);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGroupUpdates", new { id = groupUpdates.GroupUpdateId }, groupUpdates);
        }

        // DELETE: api/GroupUpdates/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<GroupUpdates>> DeleteGroupUpdates(int id)
        {
            var groupUpdates = await _context.GroupUpdates.FindAsync(id);
            if (groupUpdates == null)
            {
                return NotFound();
            }

            _context.GroupUpdates.Remove(groupUpdates);
            await _context.SaveChangesAsync();

            return groupUpdates;
        }

        private bool GroupUpdatesExists(int id)
        {
            return _context.GroupUpdates.Any(e => e.GroupUpdateId == id);
        }
    }
}
