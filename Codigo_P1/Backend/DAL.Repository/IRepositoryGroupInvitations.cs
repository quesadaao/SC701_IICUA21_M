using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using data = DAL.DO.Objects;

namespace DAL.Repository
{
    public interface IRepositoryGroupInvitations : IRepository<data.GroupInvitations>
    {
        Task<IEnumerable<data.GroupInvitations>> GetAllWithAsAsync();
        Task<data.GroupInvitations> GetOneByIdAsAsync(int id);
    }
}
