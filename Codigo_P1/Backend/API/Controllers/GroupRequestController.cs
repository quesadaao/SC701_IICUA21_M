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
    public class GroupRequestsController : ControllerBase
    {
        private readonly SolutionDbContext _context;

        public GroupRequestsController(SolutionDbContext context)
        {
            _context = context;
        }

        // GET: api/GroupRequests
        [HttpGet]
        public async Task<ActionResult<IEnumerable<data.GroupRequests>>> GetGroupRequests()
        {
            var res = await new BS.GroupRequests(_context).GetAllWithAsync();
            return res.ToList();

        }

        // GET: api/GroupRequests/5
        [HttpGet("{id}")]
        public async Task<ActionResult<data.GroupRequests>> GetGroupRequests(int id)
        {
            var groupRequests = await new BS.GroupRequests(_context).GetOneByIdWithAsync(id);

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
        public async Task<IActionResult> PutGroupRequests(int id, data.GroupRequests groupRequests)
        {
            if (id != groupRequests.GroupRequestId)
            {
                return BadRequest();
            }

            try
            {
                new BS.GroupRequests(_context).Update(groupRequests);
            }
            catch (Exception ee)
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
        public async Task<ActionResult<data.GroupRequests>> PostGroupRequests(data.GroupRequests groupRequests)
        {
            new BS.GroupRequests(_context).Insert(groupRequests);
            return CreatedAtAction("GetGroupRequests", new { id = groupRequests.GroupRequestId }, groupRequests);
        }

        // DELETE: api/GroupRequests/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<data.GroupRequests>> DeleteGroupRequests(int id)
        {
            var groupRequests = new BS.GroupRequests(_context).GetOneByID(id);
            if (groupRequests == null)
            {
                return NotFound();
            }

            new BS.GroupRequests(_context).Delete(groupRequests);
            return groupRequests;
        }

        private bool GroupRequestsExists(int id)
        {
            return (new BS.GroupInvitations(_context).GetOneByID(id) != null);
        }
    }
}
