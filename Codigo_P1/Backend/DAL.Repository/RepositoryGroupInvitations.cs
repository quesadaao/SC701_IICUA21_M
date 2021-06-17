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
    public class RepositoryGroupInvitations : Repository<data.GroupInvitations>, IRepositoryGroupInvitations
    {

        public RepositoryGroupInvitations(SolutionDbContext context) : base(context)
        {

        }

        public async Task<IEnumerable<GroupInvitations>> GetAllWithAsAsync()
        {
            return await _db.GroupInvitations
                .Include(m => m.Group)
                .ToListAsync();
        }

        public async Task<GroupInvitations> GetOneByIdAsAsync(int id)
        {
            return await _db.GroupInvitations
               .Include(m => m.Group)
               .SingleOrDefaultAsync(m => m.GroupInvitationId == id);
        }

        private SolutionDbContext _db
        {
            get { return dbContext as SolutionDbContext; }
        }
    }
}
