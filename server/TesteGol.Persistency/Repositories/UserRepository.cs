using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using TesteGol.Model.Entities;
using TesteGol.Model.Repositories;
using TesteGol.Persistency.Context;
using TesteGol.Persistency.Repositories.Base;

namespace TesteGol.Persistency.Repositories
{
    public class UserRepository : RepositoryBase<User, DefaultContext>, IUserRepository
    {
        public UserRepository(DefaultContext context) : base(context)
        {
        }


        public async Task<User> GetByLoginAndPassWord(string login, string password)
        {
            return await _dbSet
                .FirstOrDefaultAsync(x => x.Login == login && x.Password == password)
                .ConfigureAwait(false);
        }

    }
}
