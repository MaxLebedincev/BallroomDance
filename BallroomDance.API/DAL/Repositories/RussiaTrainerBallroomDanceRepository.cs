using BallroomDance.API.DAL.Interfaces;
using BallroomDance.API.Domain.Entity;

namespace BallroomDance.API.DAL.Repositories
{
    public class RussiaTrainerBallroomDanceRepository : BaseRepository<RussiaTrainerBallroomDance>, IBaseRepository<RussiaTrainerBallroomDance>
    {
        public RussiaTrainerBallroomDanceRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
