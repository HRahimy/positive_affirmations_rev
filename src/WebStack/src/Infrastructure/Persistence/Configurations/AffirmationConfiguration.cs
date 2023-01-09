using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebStack.Domain.Entities;

namespace WebStack.Infrastructure.Persistence.Configurations;
public class AffirmationConfiguration : IEntityTypeConfiguration<Affirmation>
{
    public void Configure(EntityTypeBuilder<Affirmation> builder)
    {
        builder.Property(t => t.Title)
            .HasMaxLength(200)
            .IsRequired();
    }
}
