using BallroomDanceAPI.DAL.Interfaces;
using BallroomDanceAPI.Domain.Entity;

namespace BallroomDanceAPI.DAL.Repositories
{
    public class RussiaTrainerBallroomDanceRepository : BaseRepository<RussiaTrainerBallroomDance>, IBaseRepository<RussiaTrainerBallroomDance>
    {
        public RussiaTrainerBallroomDanceRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
