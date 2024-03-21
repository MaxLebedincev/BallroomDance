using BallroomDance.API.DAL.Interfaces;
using BallroomDance.API.Domain.Entity;

namespace BallroomDance.API.DAL.Repositories
{
    public class UserRoleRepository : BaseRepository<UserRole>, IBaseRepository<UserRole>
    {
        public UserRoleRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
