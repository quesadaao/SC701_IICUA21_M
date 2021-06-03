using DAL.DO.Interfaces;
using DAL.EF;
using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using data = DAL.DO.Objects;

namespace DAL
{

    public class GroupInvitations : ICRUD<data.GroupInvitations>
    {
        private Repository<data.GroupInvitations> _repo = null;

        public GroupInvitations(SolutionDbContext solutionDbContext)
        {
            _repo = new Repository<data.GroupInvitations>(solutionDbContext);
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

        public data.GroupInvitations GetOneByID(int id)
        {
            return _repo.GetOneById(id);
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
