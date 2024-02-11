using Jazani.Domain.Admins.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Jazani.Infrastructure.Cores.Converters;

namespace Jazani.Infrastructure.Admins.Configurations;

public class ManagementConfiguration : IEntityTypeConfiguration<Management>
{
    public void Configure(EntityTypeBuilder<Management> builder)
    {
        builder.ToTable("management", "adm");
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id).HasColumnName("id");
        builder.Property(e => e.Name).HasColumnName("name").HasMaxLength(50).IsRequired();
        builder.Property(e => e.Description).HasColumnName("description").HasMaxLength(250);
        builder.Property(e => e.SectorsInCharge).HasColumnName("sectorsincharge").HasDefaultValue(0).IsRequired();
        builder.Property(e => e.AnnualBudget).HasColumnName("annualbudget").HasColumnType("decimal(18,3)").HasDefaultValue(0).IsRequired();
        builder.Property(e => e.CreationDate).HasColumnName("creationdate");
        builder.Property(e => e.Tasks).HasColumnName("tasks").HasMaxLength(250);
        builder.Property(e => e.AreaId).HasColumnName("areaid").IsRequired();
        builder.Property(e => e.OfficeId).HasColumnName("officeid").IsRequired();
        builder.Property(e => e.RegistrationDate).HasColumnName("registrationdate")
            .HasConversion(new DateTimeToDateTimeOffset())
            .IsRequired();
        builder.Property(e => e.State).HasColumnName("state").HasDefaultValue(true).IsRequired();

        builder.HasOne(e => e.Area)
            .WithMany(e => e.Managements)
            .HasForeignKey(e => e.AreaId);
        
        builder.HasOne(e => e.Office)
            .WithMany(e => e.Managements)
            .HasForeignKey(e => e.OfficeId);
    }
}