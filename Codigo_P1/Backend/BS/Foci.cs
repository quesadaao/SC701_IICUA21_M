using DAL.DO.Interfaces;
using DAL.EF;
using System;
using System.Collections.Generic;
using System.Text;
using data = DAL.DO.Objects;

namespace BS
{
    public class Foci : ICRUD<data.Foci>
    {
        private SolutionDbContext context;

        public Foci(SolutionDbContext _context) {
            context = _context;
        }
        public void Delete(data.Foci t)
        {
            new DAL.Foci(context).Delete(t);
        }

        public IEnumerable<data.Foci> GetAll()
        {
            return new DAL.Foci(context).GetAll();
        }

        public data.Foci GetOneByID(int id)
        {
            return new DAL.Foci(context).GetOneByID(id);
        }

        public void Insert(data.Foci t)
        {
            new DAL.Foci(context).Insert(t);
        }

        public void Update(data.Foci t)
        {
            new DAL.Foci(context).Update(t);
        }
    }
}
