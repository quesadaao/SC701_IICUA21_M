using DAL.DO.Objects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using data = DAL.DO.Objects;
using DAL.EF;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repository
{
    public class RepositoryFoci : Repository<data.Foci>, IRepositoryFoci
    {

        public RepositoryFoci(SolutionDbContext context) : base(context)
        {

        }

        public async Task<IEnumerable<Foci>> GetAllWithAsAsync()
        {
            return await _db.Foci
                .Include(m => m.Group)
                .ToListAsync();
        }

        public async Task<Foci> GetOneByIdAsAsync(int id)
        {
            return await _db.Foci
               .Include(m => m.Group)
               .SingleOrDefaultAsync(m => m.FocusId == id);
        }

        private SolutionDbContext _db
        {
            get { return dbContext as SolutionDbContext; }
        }
    }
}
