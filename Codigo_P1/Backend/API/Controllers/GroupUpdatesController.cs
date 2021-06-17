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
    public class GroupUpdatesController : ControllerBase
    {
        private readonly SolutionDbContext _context;
        private readonly IMapper _mapper;

        public GroupUpdatesController(SolutionDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/GroupUpdates
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DataModels.GroupUpdates>>> GetGroupUpdates()
        {
            //return await _context.GroupUpdates.ToListAsync();

            var res = new BS.GroupUpdates(_context).GetAll();

            var mapaux = _mapper.Map<IEnumerable<data.GroupUpdates>, IEnumerable<DataModels.GroupUpdates>>(res).ToList();

            return mapaux;
        }

        // GET: api/GroupUpdates/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DataModels.GroupUpdates>> GetGroupUpdates(int id)
        {
            var groupUpdates = new BS.GroupUpdates(_context).GetOneByID(id);
            var mapaux = _mapper.Map<data.GroupUpdates, DataModels.GroupUpdates>(groupUpdates);
            if (groupUpdates == null)
            {
                return NotFound();
            }

            return mapaux;
        }

        // PUT: api/GroupUpdates/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGroupUpdates(int id, DataModels.GroupUpdates groupUpdates)
        {
            if (id != groupUpdates.GroupUpdateId)
            {
                return BadRequest();
            }

            try
            {
                var mapaux = _mapper.Map<DataModels.GroupUpdates, data.GroupUpdates>(groupUpdates);
                new BS.GroupUpdates(_context).Update(mapaux);
            }
            catch (Exception ee)
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
        public async Task<ActionResult<DataModels.GroupUpdates>> PostGroupUpdates(DataModels.GroupUpdates groupUpdates)
        {
            var mapaux = _mapper.Map<DataModels.GroupUpdates, data.GroupUpdates>(groupUpdates);
            new BS.GroupUpdates(_context).Insert(mapaux);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGroupUpdates", new { id = groupUpdates.GroupUpdateId }, groupUpdates);
        }

        // DELETE: api/GroupUpdates/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DataModels.GroupUpdates>> DeleteGroupUpdates(int id)
        {
            var groupUpdates = new BS.GroupUpdates(_context).GetOneByID(id);
            if (groupUpdates == null)
            {
                return NotFound();
            }

            new BS.GroupUpdates(_context).Delete(groupUpdates);
            var mapaux = _mapper.Map<data.GroupUpdates, DataModels.GroupUpdates>(groupUpdates);
            return mapaux;
        }

        private bool GroupUpdatesExists(int id)
        {
            return (new BS.GroupUpdates(_context).GetOneByID(id) != null);
        }
    }
}
