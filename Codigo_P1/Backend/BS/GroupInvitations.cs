using DAL.DO.Interfaces;
using DAL.EF;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using data = DAL.DO.Objects;

namespace BS
{

    public class GroupInvitations : ICRUD<data.GroupInvitations>
    {
        private SolutionDbContext context;

        public GroupInvitations(SolutionDbContext _context)
        {
            context = _context;
        }
        public void Delete(data.GroupInvitations t)
        {
            new DAL.GroupInvitations(context).Delete(t);
        }

        public IEnumerable<data.GroupInvitations> GetAll()
        {
            return new DAL.GroupInvitations(context).GetAll();
        }

        public async Task<IEnumerable<data.GroupInvitations>> GetAllWithAsync()
        {
            return await new DAL.GroupInvitations(context).GetAllWithAsync();
        }

        public data.GroupInvitations GetOneByID(int id)
        {
            return new DAL.GroupInvitations(context).GetOneByID(id);
        }

        public async Task<data.GroupInvitations> GetOneByIdWithAsync(int id)
        {
            return await new DAL.GroupInvitations(context).GetOneByIdWithAsync(id);
        }

        public void Insert(data.GroupInvitations t)
        {
            new DAL.GroupInvitations(context).Insert(t);
        }

        public void Update(data.GroupInvitations t)
        {
            new DAL.GroupInvitations(context).Update(t);
        }
    }
}
