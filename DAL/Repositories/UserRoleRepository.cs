using BallroomDanceAPI.DAL.Interfaces;
using BallroomDanceAPI.Domain.Entity;

namespace BallroomDanceAPI.DAL.Repositories
{
    public class UserRoleRepository : BaseRepository<UserRole>, IBaseRepository<UserRole>
    {
        public UserRoleRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
