using BallroomDanceAPI.DAL.Interfaces;
using BallroomDanceAPI.Domain.Entity;

namespace BallroomDanceAPI.DAL.Repositories
{
    public class MemberDanceGroupRepository : BaseRepository<MemberDanceGroup>, IBaseRepository<MemberDanceGroup>
    {
        public MemberDanceGroupRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
