using DAL.DO.Interfaces;
using DAL.EF;
using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using data = DAL.DO.Objects;

namespace DAL
{

    public class Groups : ICRUD<data.Groups>
    {
        private Repository<data.Groups> _repo = null;

        public Groups(SolutionDbContext solutionDbContext)
        {
            _repo = new Repository<data.Groups>(solutionDbContext);
        }
        public void Delete(data.Groups t)
        {
            _repo.Delete(t);
            _repo.Commit();
        }

        public IEnumerable<data.Groups> GetAll()
        {
            return _repo.GetAll();
        }

        public Task<IEnumerable<data.Groups>> GetAllWithAsync()
        {
            throw new NotImplementedException();
        }

        public data.Groups GetOneByID(int id)
        {
            return _repo.GetOneById(id);
        }

        public Task<data.Groups> GetOneByIdWithAsync(int id)
        {
            throw new NotImplementedException();
        }

        // Hacer filtro por fechas para obtener data 
        public IEnumerable<data.Groups> GetAllbyDate(DateTime dateTime)
        {
            return _repo.Searh(s => s.CreatedDate > dateTime);
        }

        // Hacer filtro por texto para obtener data 
        public data.Groups GetOnebyTextDescription(data.Groups t, string filter)
        {
            // Buscando por Description 
            //return _repo.GetOne(s => s.GroupId == t.GroupId && s.Description.Contains(filter));

            //Buscando por GroupName
            //return _repo.GetOne(s => s.GroupId == t.GroupId && s.GroupName.Contains(filter));

            return _repo.GetOne(s => s.Description.Contains(filter));
        }

        public void Insert(data.Groups t)
        {
            _repo.Insert(t);
            _repo.Commit();
        }

        public void Update(data.Groups t)
        {
            _repo.Update(t);
            _repo.Commit();
        }
    }
}
