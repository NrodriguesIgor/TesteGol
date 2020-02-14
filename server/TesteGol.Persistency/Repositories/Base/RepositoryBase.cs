using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using TesteGol.Model.Base;
using TesteGol.Persistency.Context;

namespace TesteGol.Persistency.Repositories.Base
{
    public abstract class RepositoryBase<TEntity, TContext> : IRepositoryBase<TEntity, TContext>
       where TEntity : Entity
       where TContext : DbContext
    {
        protected readonly DefaultContext _dbContext;
        protected readonly DbSet<TEntity> _dbSet;

        public RepositoryBase(DefaultContext context)
        {
            if (context == null)
            {
                return;
            }

            _dbContext = context;
            _dbSet = _dbContext.Set<TEntity>();
        }

        public async Task Create(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public async Task Update(Guid id, TEntity entity)
        {
            await Task.Run(() => _dbSet.Update(entity)).ConfigureAwait(false);
        }

        public async Task Delete(Guid id)
        {
            var value = await _dbSet.FindAsync(id);
            _dbSet.Remove(value);
        }

        public async Task<IQueryable<TEntity>> GetAll()
        {
            return await Task.Run(() => _dbSet.AsNoTracking()).ConfigureAwait(false);
        }

        public async Task<TEntity> GetById(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }

        public void ChangeState(TEntity entity, EntityState state)
        {
            _dbContext.Entry(entity).State = state;
        }
    }
}
