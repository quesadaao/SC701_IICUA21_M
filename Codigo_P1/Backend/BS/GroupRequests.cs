using DAL.DO.Interfaces;
using DAL.EF;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using data = DAL.DO.Objects;
namespace BS
{

    public class GroupRequests : ICRUD<data.GroupRequests>
    {
        private SolutionDbContext context;

        public GroupRequests(SolutionDbContext _context)
        {
            context = _context;
        }
        public void Delete(data.GroupRequests t)
        {
            new DAL.GroupRequests(context).Delete(t);
        }

        public IEnumerable<data.GroupRequests> GetAll()
        {
            return new DAL.GroupRequests(context).GetAll();
        }

        public async Task<IEnumerable<data.GroupRequests>> GetAllWithAsync()
        {
            return await new DAL.GroupRequests(context).GetAllWithAsync();
        }

        public data.GroupRequests GetOneByID(int id)
        {
            return new DAL.GroupRequests(context).GetOneByID(id);
        }

        public async Task<data.GroupRequests> GetOneByIdWithAsync(int id)
        {
            return await new DAL.GroupRequests(context).GetOneByIdWithAsync(id);
        }

        public void Insert(data.GroupRequests t)
        {
            new DAL.GroupRequests(context).Insert(t);
        }

        public void Update(data.GroupRequests t)
        {
            new DAL.GroupRequests(context).Update(t);
        }
    }
}
