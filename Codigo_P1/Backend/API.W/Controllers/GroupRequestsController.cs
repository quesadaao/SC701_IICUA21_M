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
    public class GroupRequestsController : ControllerBase
    {
        private readonly SocialGoalContext _context;

        public GroupRequestsController(SocialGoalContext context)
        {
            _context = context;
        }

        // GET: api/GroupRequests
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GroupRequests>>> GetGroupRequests()
        {
            return await _context.GroupRequests.ToListAsync();
        }

        // GET: api/GroupRequests/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GroupRequests>> GetGroupRequests(int id)
        {
            var groupRequests = await _context.GroupRequests.FindAsync(id);

            if (groupRequests == null)
            {
                return NotFound();
            }

            return groupRequests;
        }

        // PUT: api/GroupRequests/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGroupRequests(int id, GroupRequests groupRequests)
        {
            if (id != groupRequests.GroupRequestId)
            {
                return BadRequest();
            }

            _context.Entry(groupRequests).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GroupRequestsExists(id))
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

        // POST: api/GroupRequests
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<GroupRequests>> PostGroupRequests(GroupRequests groupRequests)
        {
            _context.GroupRequests.Add(groupRequests);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGroupRequests", new { id = groupRequests.GroupRequestId }, groupRequests);
        }

        // DELETE: api/GroupRequests/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<GroupRequests>> DeleteGroupRequests(int id)
        {
            var groupRequests = await _context.GroupRequests.FindAsync(id);
            if (groupRequests == null)
            {
                return NotFound();
            }

            _context.GroupRequests.Remove(groupRequests);
            await _context.SaveChangesAsync();

            return groupRequests;
        }

        private bool GroupRequestsExists(int id)
        {
            return _context.GroupRequests.Any(e => e.GroupRequestId == id);
        }
    }
}
