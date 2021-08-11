using DAL.DO.Interfaces;
using DAL.EF;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using data = DAL.DO.Objects;

namespace BS
{
    public class Pies : ICRUD<data.Pies>
    {
        private SolutionDbContext context;

        public Pies(SolutionDbContext _context)
        {
            context = _context;
        }
        public void Delete(data.Pies t)
        {
            new DAL.Pies(context).Delete(t);
        }

        public IEnumerable<data.Pies> GetAll()
        {
            return new DAL.Pies(context).GetAll();
        }

        public Task<IEnumerable<data.Pies>> GetAllWithAsync()
        {
            throw new NotImplementedException();
        }

        public data.Pies GetOneByID(int id)
        {
            return new DAL.Pies(context).GetOneByID(id);
        }

        public Task<data.Pies> GetOneByIdWithAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(data.Pies t)
        {
            new DAL.Pies(context).Insert(t);
        }

        public void Update(data.Pies t)
        {
            new DAL.Pies(context).Update(t);
        }
    }
}
