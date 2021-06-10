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
    public class FociController : ControllerBase
    {
        private readonly SolutionDbContext _context;

        private readonly IMapper _mapper;

        public FociController(SolutionDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Foci
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DataModels.Foci>>> GetFoci()
        {
            var res = await new BS.Foci(_context).GetAllWithAsync();

            var mapaux = _mapper.Map<IEnumerable<data.Foci>,IEnumerable<DataModels.Foci>>(res).ToList();

            return mapaux;

        }

        // GET: api/Foci/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DataModels.Foci>> GetFoci(int id)
        {
            var foci = await new BS.Foci(_context).GetOneByIdWithAsync(id);
            var mapaux = _mapper.Map<data.Foci, DataModels.Foci>(foci);
            if (foci == null)
            {
                return NotFound();
            }

            return mapaux;
        }

        // PUT: api/Foci/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFoci(int id, DataModels.Foci foci)
        {
            if (id != foci.FocusId)
            {
                return BadRequest();
            }

            try
            {
                var mapaux = _mapper.Map<DataModels.Foci, data.Foci>(foci);
                new BS.Foci(_context).Update(mapaux);
            }
            catch (Exception ee)
            {
                if (!FociExists(id))
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

        // POST: api/Foci
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<DataModels.Foci>> PostFoci(DataModels.Foci foci)
        {
            var mapaux = _mapper.Map<DataModels.Foci, data.Foci>(foci);
            new BS.Foci(_context).Insert(mapaux);
            return CreatedAtAction("GetFoci", new { id = foci.FocusId }, foci);
        }

        // DELETE: api/Foci/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DataModels.Foci>> DeleteFoci(int id)
        {
            var foci = new BS.Foci(_context).GetOneByID(id);
            if (foci == null)
            {
                return NotFound();
            }

            new BS.Foci(_context).Delete(foci);
            var mapaux = _mapper.Map<data.Foci, DataModels.Foci>(foci);
            return mapaux;
        }

        private bool FociExists(int id)
        {
            return (new BS.Foci(_context).GetOneByID(id) != null);
        }
    }
}
