using DAL.DO.Interfaces;
using DAL.EF;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using data = DAL.DO.Objects;


namespace BS
{
    public class GroupUpdates : ICRUD<data.GroupUpdates>
    {
        private SolutionDbContext context;

        public GroupUpdates(SolutionDbContext _context)
        {
            context = _context;
        }
        public void Delete(data.GroupUpdates t)
        {
            new DAL.GroupUpdates(context).Delete(t);
        }

        public IEnumerable<data.GroupUpdates> GetAll()
        {
            return new DAL.GroupUpdates(context).GetAll();
        }

        public Task<IEnumerable<data.GroupUpdates>> GetAllWithAsync()
        {
            throw new NotImplementedException();
        }

        public data.GroupUpdates GetOneByID(int id)
        {
            return new DAL.GroupUpdates(context).GetOneByID(id);
        }

        public Task<data.GroupUpdates> GetOneByIdWithAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(data.GroupUpdates t)
        {
            new DAL.GroupUpdates(context).Insert(t);
        }

        public void Update(data.GroupUpdates t)
        {
            new DAL.GroupUpdates(context).Update(t);
        }
    }
}
