using BallroomDanceAPI.DAL.Interfaces;
using BallroomDanceAPI.Domain.Entity;

namespace BallroomDanceAPI.DAL.Repositories
{
    public class DanceGroupRepository : BaseRepository<DanceGroup>, IBaseRepository<DanceGroup>
    {
        public DanceGroupRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
