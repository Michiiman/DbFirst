using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration
{
    public class DriverConfiguration : IEntityTypeConfiguration<Driver>
    {
        public void Configure(EntityTypeBuilder<Driver> builder)
        {
            builder.HasKey(e => e.Id).HasName("PRIMARY");

            builder.ToTable("driver");

            builder.Property(e => e.Id).HasColumnName("id");
            builder.Property(e => e.Age).HasColumnName("age");
            builder.Property(e => e.Name)
                .HasMaxLength(60)
                .HasColumnName("name");

            builder
            .HasMany(p=>p.Teams)
            .WithMany(p=>p.Drivers)
            .UsingEntity<TeamDriver>(
            j=>j
            .HasOne(pt=>pt.Team)
            .WithMany(t=>t.TeamDrivers)
            .HasForeignKey(pt=>pt.IdTeam),
            j => j
            .HasOne(pt => pt.Driver)
            .WithMany(t => t.TeamDrivers)
            .HasForeignKey(pt => pt.IdDriver),
            j =>
            {
            j.ToTable("teamdriver");
            j.HasKey(t => new { t.IdDriver, t.IdTeam});
            });
        }
    }
}