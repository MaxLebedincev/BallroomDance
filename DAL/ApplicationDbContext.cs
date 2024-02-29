using BallroomDanceAPI.DAL.Configurations;
using BallroomDanceAPI.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace BallroomDanceAPI.DAL
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new TypeBallroomDanceConfiguration());
            modelBuilder.ApplyConfiguration(new RussiaTrainerBallroomDanceConfiguration());
            modelBuilder.ApplyConfiguration(new DanceGroupConfiguration());
            modelBuilder.ApplyConfiguration(new ServerFileConfiguration());
            modelBuilder.ApplyConfiguration(new MemberDanceGroupConfiguration());
        }
    }
}
