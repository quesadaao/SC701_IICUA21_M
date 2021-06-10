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
    public class RepositoryGroupRequest : Repository<data.GroupRequests>, IRepositoryGroupRequest
    {

        public RepositoryGroupRequest(SolutionDbContext context) : base(context) { 
        
        }

        public async Task<IEnumerable<GroupRequests>> GetAllWithAsAsync()
        {
            return await _db.GroupRequests
                .Include(m => m.Group)
                .ToListAsync();
        }

        public async Task<GroupRequests> GetOneByIdAsAsync(int id)
        {
            return await _db.GroupRequests
               .Include(m => m.Group)
               .SingleOrDefaultAsync(m => m.GroupId == id);
        }

        private SolutionDbContext _db {
            get { return dbContext as SolutionDbContext; }
        }
    }
}
