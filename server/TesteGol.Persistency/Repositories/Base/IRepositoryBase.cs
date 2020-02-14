using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using TesteGol.Model.Base;

namespace TesteGol.Persistency.Repositories.Base
{
    public interface IRepositoryBase<TEntity, TContext>
       where TEntity : Entity
       where TContext : DbContext
    {
        Task<IQueryable<TEntity>> GetAll();
        Task<TEntity> GetById(Guid id);
        Task Create(TEntity entity);
        Task Update(Guid id, TEntity entity);
        Task Delete(Guid id);

    }
}
