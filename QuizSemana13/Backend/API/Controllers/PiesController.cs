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
    public class PiesController : Controller
    {
        private readonly SolutionDbContext _context;
        private readonly IMapper _mapper;

        public PiesController(SolutionDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        // GET: api/Pies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DataModels.Pies>>> GetPies()
        {

            var res = new BS.Pies(_context).GetAll();
            var mapaux = _mapper.Map<IEnumerable<data.Pies>, IEnumerable<DataModels.Pies>>(res).ToList();

            return mapaux;
        }

        // GET: api/Pies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DataModels.Pies>> GetPies(int id)
        {
            var pies = new BS.Pies(_context).GetOneByID(id);
            var mapaux = _mapper.Map<data.Pies, DataModels.Pies>(pies);


            if (pies == null)
            {
                return NotFound();
            }

            return mapaux;
        }

        // PUT: api/Pies/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPies(int id, DataModels.Pies pies)
        {
            if (id != pies.Id)
            {
                return BadRequest();
            }
            
            try
            {
                var mapaux = _mapper.Map<DataModels.Pies, data.Pies>(pies);
                new BS.Pies(_context).Update(mapaux);
            }
            catch (Exception ee)
            {
                if (!Exists(id))
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

        // POST: api/Pies
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<DataModels.Pies>> PostPies(DataModels.Pies pies)
        {
            var mapaux = _mapper.Map<DataModels.Pies, data.Pies>(pies);
            new BS.Pies(_context).Insert(mapaux);

            return CreatedAtAction("GetPies", new { id = pies.Id }, pies);
        }

        // DELETE: api/Pies/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DataModels.Pies>> DeletePies(int id)
        {

            var pies = new BS.Pies(_context).GetOneByID(id);
            if (pies == null)
            {
                return NotFound();
            }

            new BS.Pies(_context).Delete(pies);
            var mapaux = _mapper.Map<data.Pies, DataModels.Pies>(pies);

            return mapaux;
        }

        private bool Exists(int id)
        {
            return (new BS.Pies(_context).GetOneByID(id) != null);
        }
    }
}
