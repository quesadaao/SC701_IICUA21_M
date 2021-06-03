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
    public class FociController : ControllerBase
    {
        private readonly SolutionDbContext _context;

        public FociController(SolutionDbContext context)
        {
            _context = context;
        }

        // GET: api/Foci
        [HttpGet]
        public async Task<ActionResult<IEnumerable<data.Foci>>> GetFoci()
        {
            return new BS.Foci(_context).GetAll().ToList();
        }

        // GET: api/Foci/5
        [HttpGet("{id}")]
        public async Task<ActionResult<data.Foci>> GetFoci(int id)
        {
            var foci = new BS.Foci(_context).GetOneByID(id);

            if (foci == null)
            {
                return NotFound();
            }

            return foci;
        }

        // PUT: api/Foci/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFoci(int id, data.Foci foci)
        {
            if (id != foci.FocusId)
            {
                return BadRequest();
            }

            try
            {
                new BS.Foci(_context).Update(foci);
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
        public async Task<ActionResult<data.Foci>> PostFoci(data.Foci foci)
        {
            new BS.Foci(_context).Insert(foci);
            return CreatedAtAction("GetFoci", new { id = foci.FocusId }, foci);
        }

        // DELETE: api/Foci/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<data.Foci>> DeleteFoci(int id)
        {
            var foci = new BS.Foci(_context).GetOneByID(id);
            if (foci == null)
            {
                return NotFound();
            }

            new BS.Foci(_context).Delete(foci);

            return foci;
        }

        private bool FociExists(int id)
        {
            return (new BS.Foci(_context).GetOneByID(id) != null);
        }
    }
}
