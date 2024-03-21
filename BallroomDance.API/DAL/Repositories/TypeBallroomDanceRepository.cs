using BallroomDance.API.DAL.Interfaces;
using BallroomDance.API.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace BallroomDance.API.DAL.Repositories
{
    public class TypeBallroomDanceRepository : BaseRepository<TypeBallroomDance>, IBaseRepository<TypeBallroomDance>
    {
        public TypeBallroomDanceRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
