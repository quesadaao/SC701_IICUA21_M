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

    public class GroupInvitations : ICRUD<data.GroupInvitations>
    {
        private RepositoryGroupInvitations _repo = null;

        public GroupInvitations(SolutionDbContext solutionDbContext)
        {
            _repo = new RepositoryGroupInvitations(solutionDbContext);
        }
        public void Delete(data.GroupInvitations t)
        {
            _repo.Delete(t);
            _repo.Commit();
        }

        public IEnumerable<data.GroupInvitations> GetAll()
        {
            return _repo.GetAll();
        }

        public async Task<IEnumerable<data.GroupInvitations>> GetAllWithAsync()
        {
            return await _repo.GetAllWithAsAsync();
        }

        public data.GroupInvitations GetOneByID(int id)
        {
            return _repo.GetOneById(id);
        }

        public async Task<data.GroupInvitations> GetOneByIdWithAsync(int id)
        {
            return await _repo.GetOneByIdAsAsync(id);
        }

        public void Insert(data.GroupInvitations t)
        {
            _repo.Insert(t);
            _repo.Commit();
        }

        public void Update(data.GroupInvitations t)
        {
            _repo.Update(t);
            _repo.Commit();
        }
    }
}
