using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SunstoneProject.Infrastructure.Persistence.EntityFramework.Mappings
{
    public class GemstoneMapping : IEntityTypeConfiguration<Domain.Entities.Gemstone>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.Gemstone> builder)
        {
            builder.HasKey(g => g.Id);

            builder.Property(g => g.Name)
                .IsRequired()
                .HasColumnType("varchar(30)");

            builder.Property(g => g.Carat)
                .IsRequired()
                .HasColumnType("decimal");

            builder.Property(g => g.Clarity)
                .IsRequired()
                .HasColumnType("decimal");

            builder.Property(g => g.Created)
                .IsRequired()
                .HasColumnType("date");

            builder.ToTable("Gemstones");

        }
    }
}
