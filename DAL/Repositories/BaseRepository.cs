using BallroomDanceAPI.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace BallroomDanceAPI.DAL.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext _dbContext;
        protected readonly DbSet<TEntity> _dbSet;
        public BaseRepository(DbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _dbSet = _dbContext.Set<TEntity>();
        }

        public TEntity CreateAsync(TEntity entity)
        {
            return _dbSet.Add(entity).Entity;
        }

        public void DeleteAsync(TEntity entity)
        {
            _dbSet.Remove(entity);
        }

        public virtual IQueryable<TEntity> GetAll()
        {
            return _dbSet;
        }

        public virtual void Update(TEntity entity)
        {
            _dbSet.Update(entity);
        }
    }
}
