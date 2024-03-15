using BallroomDanceAPI.DAL.Interfaces;
using BallroomDanceAPI.Domain.Entity;

namespace BallroomDanceAPI.DAL.Repositories
{
    public class ServerFileRepository : BaseRepository<ServerFile>, IBaseRepository<ServerFile>
    {
        public ServerFileRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
