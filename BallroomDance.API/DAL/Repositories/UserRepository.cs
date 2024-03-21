using BallroomDance.API.DAL.Interfaces;
using BallroomDance.API.Domain.Entity;

namespace BallroomDance.API.DAL.Repositories
{
    public class UserRepository : BaseRepository<User>, IBaseRepository<User>
    {
        public UserRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
