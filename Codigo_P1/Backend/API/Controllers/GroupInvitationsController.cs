using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using data = DAL.DO.Objects;
using DAL.EF;
using AutoMapper;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupInvitationsController : ControllerBase
    {
        private readonly SolutionDbContext _context;

        private readonly IMapper _mapper;
        public GroupInvitationsController(SolutionDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/GroupInvitations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DataModels.GroupInvitations>>> GetGroupInvitations()
        {
            var res = await new BS.GroupInvitations(_context).GetAllWithAsync();
            var mapaux = _mapper.Map<IEnumerable<data.GroupInvitations>, IEnumerable<DataModels.GroupInvitations>>(res).ToList();

            return mapaux;
        }

        // GET: api/GroupInvitations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DataModels.GroupInvitations>> GetGroupInvitations(int id)
        {
            var groupInvitations = await new BS.GroupInvitations(_context).GetOneByIdWithAsync(id);
            var mapaux = _mapper.Map<data.GroupInvitations, DataModels.GroupInvitations>(groupInvitations);
            if (groupInvitations == null)
            {
                return NotFound();
            }

            return mapaux;
        }

        // PUT: api/GroupInvitations/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGroupInvitations(int id, DataModels.GroupInvitations groupInvitations)
        {
            if (id != groupInvitations.GroupInvitationId)
            {
                return BadRequest();
            }

            try
            {
                var mapaux = _mapper.Map<DataModels.GroupInvitations, data.GroupInvitations>(groupInvitations);
                new BS.GroupInvitations(_context).Update(mapaux);

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
        public async Task<ActionResult<DataModels.GroupInvitations>> PostGroupInvitations(DataModels.GroupInvitations groupInvitations)
        {
            var mapaux = _mapper.Map<DataModels.GroupInvitations, data.GroupInvitations>(groupInvitations);
            new BS.GroupInvitations(_context).Insert(mapaux);
            return CreatedAtAction("GetGroupInvitations", new { id = groupInvitations.GroupInvitationId }, groupInvitations);
        }

        // DELETE: api/GroupInvitations/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DataModels.GroupInvitations>> DeleteGroupInvitations(int id)
        {
            var groupInvitations = new BS.GroupInvitations(_context).GetOneByID(id);
            if (groupInvitations == null)
            {
                return NotFound();
            }

            new BS.GroupInvitations(_context).Delete(groupInvitations);
            var mapaux = _mapper.Map<data.GroupInvitations, DataModels.GroupInvitations>(groupInvitations);

            return mapaux;
        }

        private bool GroupInvitationsExists(int id)
        {
            return (new BS.GroupInvitations(_context).GetOneByID(id) != null);
        }
    }
}
