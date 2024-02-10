using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Jazani.Domain.Admins.Models;
using Jazani.Infrastructure.Cores.Converters;

namespace Jazani.Infrastructure.Admins.Configurations
{
    public class AreaConfiguration : IEntityTypeConfiguration<Area>
    {
        public void Configure(EntityTypeBuilder<Area> builder)
        {
            builder.ToTable("area", "adm");

            builder.HasKey(t => t.Id);

            builder.Property(t => t.AreaTypeId).HasColumnName("areatypeid");
            builder.Property(t => t.Name).HasColumnName("name");
            builder.Property(t => t.Description).HasColumnName("description");
            builder.Property(t => t.RegistrationDate).HasColumnName("registrationdate")
                .HasConversion(new DateTimeToDateTimeOffset());
            builder.Property(t => t.State).HasColumnName("state");
        }
    }
}

