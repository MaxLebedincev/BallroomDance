namespace BallroomDanceAPI.DAL.Interfaces
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> GetAll();
        TEntity CreateAsync(TEntity entity);
        void Update(TEntity entity);
        void DeleteAsync(TEntity entity);
    }
}
