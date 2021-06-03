using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using data = DAL.DO.Objects;
using DAL.EF;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupInvitationsController : ControllerBase
    {
        private readonly SolutionDbContext _context;

        public GroupInvitationsController(SolutionDbContext context)
        {
            _context = context;
        }

        // GET: api/GroupInvitations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<data.GroupInvitations>>> GetGroupInvitations()
        {
            return new BS.GroupInvitations(_context).GetAll().ToList();
        }

        // GET: api/GroupInvitations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<data.GroupInvitations>> GetGroupInvitations(int id)
        {
            var groupInvitations = new BS.GroupInvitations(_context).GetOneByID(id);

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
        public async Task<IActionResult> PutGroupInvitations(int id, data.GroupInvitations groupInvitations)
        {
            if (id != groupInvitations.GroupInvitationId)
            {
                return BadRequest();
            }

            try
            {
                new BS.GroupInvitations(_context).Update(groupInvitations);
            }
            catch (Exception ee)
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
        public async Task<ActionResult<data.GroupInvitations>> PostGroupInvitations(data.GroupInvitations groupInvitations)
        {
            new BS.GroupInvitations(_context).Insert(groupInvitations);
            return CreatedAtAction("GetGroupInvitations", new { id = groupInvitations.GroupInvitationId }, groupInvitations);
        }

        // DELETE: api/GroupInvitations/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<data.GroupInvitations>> DeleteGroupInvitations(int id)
        {
            var groupInvitations = new BS.GroupInvitations(_context).GetOneByID(id);
            if (groupInvitations == null)
            {
                return NotFound();
            }

            new BS.GroupInvitations(_context).Delete(groupInvitations);
            return groupInvitations;
        }

        private bool GroupInvitationsExists(int id)
        {
            return _context.GroupInvitations.Any(e => e.GroupInvitationId == id);
        }
    }
}
