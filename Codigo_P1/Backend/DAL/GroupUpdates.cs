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

    public class GroupUpdates : ICRUD<data.GroupUpdates>
    {
        private Repository<data.GroupUpdates> _repo = null;

        public GroupUpdates(SolutionDbContext solutionDbContext)
        {
            _repo = new Repository<data.GroupUpdates>(solutionDbContext);
        }
        public void Delete(data.GroupUpdates t)
        {
            _repo.Delete(t);
            _repo.Commit();
        }

        public IEnumerable<data.GroupUpdates> GetAll()
        {
            return _repo.GetAll();
        }

        public Task<IEnumerable<data.GroupUpdates>> GetAllWithAsync()
        {
            throw new NotImplementedException();
        }

        public data.GroupUpdates GetOneByID(int id)
        {
            return _repo.GetOneById(id);
        }

        public Task<data.GroupUpdates> GetOneByIdWithAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(data.GroupUpdates t)
        {
            _repo.Insert(t);
            _repo.Commit();
        }

        public void Update(data.GroupUpdates t)
        {
            _repo.Update(t);
            _repo.Commit();
        }
    }
}
