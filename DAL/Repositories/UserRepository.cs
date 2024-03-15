using BallroomDanceAPI.DAL.Interfaces;
using BallroomDanceAPI.Domain.Entity;

namespace BallroomDanceAPI.DAL.Repositories
{
    public class UserRepository : BaseRepository<User>, IBaseRepository<User>
    {
        public UserRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
