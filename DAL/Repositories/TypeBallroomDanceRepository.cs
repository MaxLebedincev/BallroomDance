using BallroomDanceAPI.DAL.Interfaces;
using BallroomDanceAPI.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace BallroomDanceAPI.DAL.Repositories
{
    public class TypeBallroomDanceRepository : BaseRepository<TypeBallroomDance>, IBaseRepository<TypeBallroomDance>
    {
        public TypeBallroomDanceRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
