using BallroomDance.API.DAL.Interfaces;
using BallroomDance.API.Domain.Entity;

namespace BallroomDance.API.DAL.Repositories
{
    public class DanceGroupRepository : BaseRepository<DanceGroup>, IBaseRepository<DanceGroup>
    {
        public DanceGroupRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
