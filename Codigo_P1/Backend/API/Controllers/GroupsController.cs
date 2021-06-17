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
    public class GroupsController : ControllerBase
    {

        private readonly SolutionDbContext _context;
        private readonly IMapper _mapper;

        public GroupsController(SolutionDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Groups
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DataModels.Groups>>> GetGroups()
        {
            var res = new BS.Groups(_context).GetAll();
            var mapaux = _mapper.Map<IEnumerable<data.Groups>, IEnumerable<DataModels.Groups>>(res).ToList();

            return mapaux;
        }

        // GET: api/Groups/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DataModels.Groups>> GetGroups(int id)
        {
            var groups = new BS.Groups(_context).GetOneByID(id);
            var mapaux = _mapper.Map<data.Groups, DataModels.Groups>(groups);


            if (groups == null)
            {
                return NotFound();
            }

            return mapaux;
        }

        // PUT: api/Groups/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGroups(int id, DataModels.Groups groups)
        {
            if (id != groups.GroupId)
            {
                return BadRequest();
            }

            try
            {
                var mapaux = _mapper.Map<DataModels.Groups, data.Groups>(groups);
                new BS.Groups(_context).Update(mapaux);
            }
            catch (Exception ee)
            {
                if (!GroupsExists(id))
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

        // POST: api/Groups
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<DataModels.Groups>> PostGroups(DataModels.Groups groups)
        {
            var mapaux = _mapper.Map<DataModels.Groups, data.Groups>(groups);
            new BS.Groups(_context).Insert(mapaux);

            return CreatedAtAction("GetGroups", new { id = groups.GroupId }, groups);
        }

        // DELETE: api/Groups/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DataModels.Groups>> DeleteGroups(int id)
        {
            var groups = new BS.Groups(_context).GetOneByID(id);
            if (groups == null)
            {
                return NotFound();
            }

            new BS.Groups(_context).Delete(groups);
            var mapaux = _mapper.Map<data.Groups, DataModels.Groups>(groups);

            return mapaux;
        }

        private bool GroupsExists(int id)
        {
            return (new BS.Groups(_context).GetOneByID(id) != null);
        }
    }
}
