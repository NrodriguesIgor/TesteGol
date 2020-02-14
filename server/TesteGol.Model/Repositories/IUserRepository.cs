using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteGol.Model.Entities;

namespace TesteGol.Model.Repositories
{
    public interface IUserRepository
    {
        Task Create(User user);
        Task Update(Guid id, User user);
        Task Delete(Guid id);
        Task<IQueryable<User>> GetAll();
        Task<User> GetById(Guid id);
        Task<User> GetByLoginAndPassWord(string login, string password);
    }
}
