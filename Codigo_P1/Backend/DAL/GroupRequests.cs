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
     public class GroupRequests : ICRUD<data.GroupRequests>
    {
        private RepositoryGroupRequest _repo = null;

        public GroupRequests(SolutionDbContext solutionDbContext)
        {
            _repo = new RepositoryGroupRequest(solutionDbContext);
        }
        public void Delete(data.GroupRequests t)
        {
            _repo.Delete(t);
            _repo.Commit();
        }

        public IEnumerable<data.GroupRequests> GetAll()
        {
            return _repo.GetAll();
        }

        public async Task<IEnumerable<data.GroupRequests>> GetAllWithAsync()
        {
            return await _repo.GetAllWithAsAsync();
        }

        public data.GroupRequests GetOneByID(int id)
        {
            return _repo.GetOneById(id);
        }

        public async Task<data.GroupRequests> GetOneByIdWithAsync(int id)
        {
            return await _repo.GetOneByIdAsAsync(id);
        }

        public void Insert(data.GroupRequests t)
        {
            _repo.Insert(t);
            _repo.Commit();
        }

        public void Update(data.GroupRequests t)
        {
            _repo.Update(t);
            _repo.Commit();
        }
    }
}
