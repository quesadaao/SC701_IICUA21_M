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
    public class GroupRequestsController : ControllerBase
    {
        private readonly SolutionDbContext _context;
        private readonly IMapper _mapper;

        public GroupRequestsController(SolutionDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/GroupRequests
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DataModels.GroupRequests>>> GetGroupRequests()
        {
            var res = await new BS.GroupRequests(_context).GetAllWithAsync();
            var mapaux = _mapper.Map<IEnumerable<data.GroupRequests>, IEnumerable<DataModels.GroupRequests>>(res).ToList();

            return mapaux;

        }

        // GET: api/GroupRequests/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DataModels.GroupRequests>> GetGroupRequests(int id)
        {
            var groupRequests = await new BS.GroupRequests(_context).GetOneByIdWithAsync(id);
            var mapaux = _mapper.Map<data.GroupRequests, DataModels.GroupRequests>(groupRequests);
            if (groupRequests == null)
            {
                return NotFound();
            }

            return mapaux;
        }

        // PUT: api/GroupRequests/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGroupRequests(int id, DataModels.GroupRequests groupRequests)
        {
            if (id != groupRequests.GroupRequestId)
            {
                return BadRequest();
            }

            try
            {
                var mapaux = _mapper.Map<DataModels.GroupRequests, data.GroupRequests>(groupRequests);
                new BS.GroupRequests(_context).Update(mapaux);
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
        public async Task<ActionResult<DataModels.GroupRequests>> PostGroupRequests(DataModels.GroupRequests groupRequests)
        {
            var mapaux = _mapper.Map<DataModels.GroupRequests, data.GroupRequests>(groupRequests);
            new BS.GroupRequests(_context).Insert(mapaux);
            return CreatedAtAction("GetGroupRequests", new { id = groupRequests.GroupRequestId }, groupRequests);
        }

        // DELETE: api/GroupRequests/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DataModels.GroupRequests>> DeleteGroupRequests(int id)
        {
            var groupRequests = new BS.GroupRequests(_context).GetOneByID(id);
            if (groupRequests == null)
            {
                return NotFound();
            }

            new BS.GroupRequests(_context).Delete(groupRequests);
            var mapaux = _mapper.Map<data.GroupRequests, DataModels.GroupRequests>(groupRequests);

            return mapaux;
        }

        private bool GroupRequestsExists(int id)
        {
            return (new BS.GroupRequests(_context).GetOneByID(id) != null);
        }
    }
}
