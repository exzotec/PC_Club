using PC_Club.Repositories.Interfaces;
using PC_Club.Models;

namespace PC_Club.Repositories.Repositories
{
    internal class UserRepository : IBaseRepository<User>
    {
        public void Create(User item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public User Get(string id)
        {
            throw new NotImplementedException();
        }

        public Task<Microsoft.AspNetCore.Mvc.ActionResult<IEnumerable<User>>> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(User item)
        {
            throw new NotImplementedException();
        }
    }
}
