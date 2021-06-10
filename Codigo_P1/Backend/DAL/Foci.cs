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
    public class Foci : ICRUD<data.Foci>
    {
        private RepositoryFoci _repo = null;

        public Foci(SolutionDbContext solutionDbContext) 
        {
            _repo = new RepositoryFoci(solutionDbContext);
        }
        public void Delete(data.Foci t)
        {
            _repo.Delete(t);
            _repo.Commit();
        }

        public IEnumerable<data.Foci> GetAll()
        {
            return _repo.GetAll();
        }

        public async Task<IEnumerable<data.Foci>> GetAllWithAsync()
        {
            return await _repo.GetAllWithAsAsync();
        }

        public data.Foci GetOneByID(int id)
        {
            return _repo.GetOneById(id);
        }

        public async Task<data.Foci> GetOneByIdWithAsync(int id)
        {
            return await _repo.GetOneByIdAsAsync(id);
        }

        public void Insert(data.Foci t)
        {
            _repo.Insert(t);
            _repo.Commit();
        }

        public void Update(data.Foci t)
        {
            _repo.Update(t);
            _repo.Commit();
        }
    }
}
