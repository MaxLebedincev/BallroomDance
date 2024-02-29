using BallroomDanceAPI.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BallroomDanceAPI.DAL.Configurations
{
    public class DanceGroupConfiguration : IEntityTypeConfiguration<DanceGroup>
    {
        public void Configure(EntityTypeBuilder<DanceGroup> builder)
        {
            builder.ToTable("DanceGroups");

            builder.HasKey(x => x.Id).HasName("DanceGroupPrimaryKey"); ;
            builder.Property(x => x.Name).HasMaxLength(250).IsRequired();
            builder.Property(x => x.DateCreated).IsRequired();

            builder
                .HasOne(dg => dg.RussiaTrainerBallroomDance)
                .WithMany(rtbd => rtbd.DanceGroups)
                .HasForeignKey(dg => dg.RussiaTrainerBallroomDanceId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
