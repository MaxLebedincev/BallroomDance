using BallroomDance.API.DAL.Configurations;
using BallroomDance.API.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace BallroomDance.API.DAL
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            //Database.EnsureDeleted();
            //Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TypeBallroomDanceConfiguration());
            modelBuilder.ApplyConfiguration(new RussiaTrainerBallroomDanceConfiguration());
            modelBuilder.ApplyConfiguration(new DanceGroupConfiguration());
            modelBuilder.ApplyConfiguration(new ServerFileConfiguration());
            modelBuilder.ApplyConfiguration(new MemberDanceGroupConfiguration());
            modelBuilder.ApplyConfiguration(new UserRoleConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
        }
    }
}
