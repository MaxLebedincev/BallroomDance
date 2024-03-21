using BallroomDance.API.DAL.Interfaces;
using BallroomDance.API.Domain.Entity;

namespace BallroomDance.API.DAL.Repositories
{
    public class MemberDanceGroupRepository : BaseRepository<MemberDanceGroup>, IBaseRepository<MemberDanceGroup>
    {
        public MemberDanceGroupRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
