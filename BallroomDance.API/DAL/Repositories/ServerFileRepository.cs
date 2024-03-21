using BallroomDance.API.DAL.Interfaces;
using BallroomDance.API.Domain.Entity;

namespace BallroomDance.API.DAL.Repositories
{
    public class ServerFileRepository : BaseRepository<ServerFile>, IBaseRepository<ServerFile>
    {
        public ServerFileRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
