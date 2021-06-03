using DAL.DO.Interfaces;
using DAL.EF;
using System;
using System.Collections.Generic;
using System.Text;
using data = DAL.DO.Objects;

namespace BS
{

    public class GroupInvitations : ICRUD<data.GroupInvitations>
    {
        private SolutionDbContext context;

        public GroupInvitations(SolutionDbContext _context)
        {
            context = _context;
        }
        public void Delete(data.GroupInvitations t)
        {
            new DAL.GroupInvitations(context).Delete(t);
        }

        public IEnumerable<data.GroupInvitations> GetAll()
        {
            return new DAL.GroupInvitations(context).GetAll();
        }

        public data.GroupInvitations GetOneByID(int id)
        {
            return new DAL.GroupInvitations(context).GetOneByID(id);
        }

        public void Insert(data.GroupInvitations t)
        {
            new DAL.GroupInvitations(context).Insert(t);
        }

        public void Update(data.GroupInvitations t)
        {
            new DAL.GroupInvitations(context).Update(t);
        }
    }
}
