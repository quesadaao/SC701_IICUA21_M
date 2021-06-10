using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using data = DAL.DO.Objects;

namespace DAL.Repository
{
    public  interface IRepositoryGroupRequest : IRepository<data.GroupRequests>
    {
        Task<IEnumerable<data.GroupRequests>> GetAllWithAsAsync();
        Task<data.GroupRequests> GetOneByIdAsAsync(int id);
    }
}
