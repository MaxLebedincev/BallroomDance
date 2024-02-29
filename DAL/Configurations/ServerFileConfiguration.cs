using BallroomDanceAPI.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BallroomDanceAPI.DAL.Configurations
{
    public class ServerFileConfiguration : IEntityTypeConfiguration<ServerFile>
    {
        public void Configure(EntityTypeBuilder<ServerFile> builder)
        {
            builder.ToTable("Files");

            builder.HasKey(x => x.Guid).HasName("FilesPrimaryKey");
            builder.Property(x => x.Guid).HasDefaultValueSql("NEWID()");
            builder.Property(x => x.Name).HasMaxLength(250).IsRequired();
            builder.Property(x => x.Size).IsRequired();
        }
    }
}
