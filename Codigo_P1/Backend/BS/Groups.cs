using DAL.DO.Interfaces;
using DAL.EF;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using data = DAL.DO.Objects;


namespace BS
{
    public class Groups : ICRUD<data.Groups>
    {
        private SolutionDbContext context;

        public Groups(SolutionDbContext _context)
        {
            context = _context;
        }
        public void Delete(data.Groups t)
        {
            new DAL.Groups(context).Delete(t);
        }

        public IEnumerable<data.Groups> GetAll()
        {
            return new DAL.Groups(context).GetAll();
        }

        public Task<IEnumerable<data.Groups>> GetAllWithAsync()
        {
            throw new NotImplementedException();
        }

        public data.Groups GetOneByID(int id)
        {
            return new DAL.Groups(context).GetOneByID(id);
        }

        public Task<data.Groups> GetOneByIdWithAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(data.Groups t)
        {
            new DAL.Groups(context).Insert(t);
        }

        public void Update(data.Groups t)
        {
            new DAL.Groups(context).Update(t);
        }
    }
}
