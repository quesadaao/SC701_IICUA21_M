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
    public class GroupInvitationsController : ControllerBase
    {
        private readonly SocialGoalContext _context;

        public GroupInvitationsController(SocialGoalContext context)
        {
            _context = context;
        }

        // GET: api/GroupInvitations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GroupInvitations>>> GetGroupInvitations()
        {
            return await _context.GroupInvitations.ToListAsync();
        }

        // GET: api/GroupInvitations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GroupInvitations>> GetGroupInvitations(int id)
        {
            var groupInvitations = await _context.GroupInvitations.FindAsync(id);

            if (groupInvitations == null)
            {
                return NotFound();
            }

            return groupInvitations;
        }

        // PUT: api/GroupInvitations/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGroupInvitations(int id, GroupInvitations groupInvitations)
        {
            if (id != groupInvitations.GroupInvitationId)
            {
                return BadRequest();
            }

            _context.Entry(groupInvitations).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GroupInvitationsExists(id))
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

        // POST: api/GroupInvitations
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<GroupInvitations>> PostGroupInvitations(GroupInvitations groupInvitations)
        {
            _context.GroupInvitations.Add(groupInvitations);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGroupInvitations", new { id = groupInvitations.GroupInvitationId }, groupInvitations);
        }

        // DELETE: api/GroupInvitations/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<GroupInvitations>> DeleteGroupInvitations(int id)
        {
            var groupInvitations = await _context.GroupInvitations.FindAsync(id);
            if (groupInvitations == null)
            {
                return NotFound();
            }

            _context.GroupInvitations.Remove(groupInvitations);
            await _context.SaveChangesAsync();

            return groupInvitations;
        }

        private bool GroupInvitationsExists(int id)
        {
            return _context.GroupInvitations.Any(e => e.GroupInvitationId == id);
        }
    }
}
