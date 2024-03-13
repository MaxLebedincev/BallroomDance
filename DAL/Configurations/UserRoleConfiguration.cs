using BallroomDanceAPI.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BallroomDanceAPI.DAL.Configurations
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder.ToTable("UserRoles");

            builder.HasKey(x => x.Id).HasName("UserRolesPrimaryKey");
            builder.Property(x => x.Name).HasMaxLength(200).IsRequired();
        }
    }
}
