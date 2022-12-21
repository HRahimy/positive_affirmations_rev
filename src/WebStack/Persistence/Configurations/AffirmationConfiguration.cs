using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebStack.Domain.Entities;

namespace WebStack.Persistence.Configurations
{
    public class AffirmationConfiguration : IEntityTypeConfiguration<Affirmation>
    {
        public void Configure(EntityTypeBuilder<Affirmation> builder)
        {
            builder.Property(e => e.Id);

            builder.Property(e => e.Title)
                .IsRequired();

            builder.Property(e => e.Subtitle)
                .IsRequired(false);

            builder.Property(e => e.Active)
                .HasDefaultValue(true);
        }
    }
}
