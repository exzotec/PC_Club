using Microsoft.AspNetCore.Mvc;
using PC_Club.Data.Interface;
using PC_Club.Models;

namespace PC_Club.Data.Repository
{
    public class RoleRepository : IBaseRepository<Role>
    {
        private DataContext dbRole;

        public RoleRepository(DataContext _dbRole)
        {
            dbRole = _dbRole;
        }

        public void Create(Role item)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Role Get(string id)
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult<IEnumerable<Role>>> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(Role item)
        {
            throw new NotImplementedException();
        }
    }
}
