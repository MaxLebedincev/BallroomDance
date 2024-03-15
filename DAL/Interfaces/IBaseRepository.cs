namespace BallroomDanceAPI.DAL.Interfaces
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> GetAll();
        TEntity Create(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        ValueTask<TEntity?> FindAsync(params object?[]? keyValues);
    }
}
