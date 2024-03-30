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

        //public DbSet<TypeBallroomDance> TypeBallroomDance { get; set; }
        //public DbSet<RussiaTrainerBallroomDance> RussiaTrainerBallroomDance { get; set; }
        public DbSet<DanceGroup> DanceGroup { get; set; }
        //public DbSet<ServerFile> ServerFile { get; set; }
        //public DbSet<MemberDanceGroup> MemberDanceGroup { get; set; }
        //public DbSet<UserRole> UserRole { get; set; }
        //public DbSet<User> User { get; set; }

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
