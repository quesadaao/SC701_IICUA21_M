using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using data = DAL.DO.Objects;


namespace DAL.Repository
{
    public interface IRepositoryFoci : IRepository<data.Foci>
    {
        Task<IEnumerable<data.Foci>> GetAllWithAsAsync();
        Task<data.Foci> GetOneByIdAsAsync(int id);
    }
}
