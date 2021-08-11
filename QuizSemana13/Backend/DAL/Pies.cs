using DAL.DO.Interfaces;
using DAL.EF;
using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using data = DAL.DO.Objects;

namespace DAL
{
    public class Pies : ICRUD<data.Pies>
    {
        private Repository<data.Pies> _repo = null;

        public Pies(SolutionDbContext solutionDbContext)
        {
            _repo = new Repository<data.Pies>(solutionDbContext);
        }
        public void Delete(data.Pies t)
        {
            _repo.Delete(t);
            _repo.Commit();
        }

        public IEnumerable<data.Pies> GetAll()
        {
            return _repo.GetAll();
        }

        public Task<IEnumerable<data.Pies>> GetAllWithAsync()
        {
            throw new NotImplementedException();
        }

        public data.Pies GetOneByID(int id)
        {
            return _repo.GetOneById(id);
        }

        public Task<data.Pies> GetOneByIdWithAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(data.Pies t)
        {
            _repo.Insert(t);
            _repo.Commit();
        }

        public void Update(data.Pies t)
        {
            _repo.Update(t);
            _repo.Commit();
        }
    }
}
