using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace BallroomDance.API.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IBaseRepository<TEntity> GetRepository<TEntity>(bool hasCustomRepository = false) where TEntity : class;
        int SaveChanges();
        Task<int> SaveChangesAsync();
        int ExecuteSqlCommand(string sql, params object[] parameters);

    }
}
