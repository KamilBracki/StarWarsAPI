using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StarWarsAPI.Models;

namespace StarWarsTest.Accesslayer.EntityConfiguration
{
    public class EpisodeEntityConfiguration : IEntityTypeConfiguration<Episode>
    {
        public void Configure(EntityTypeBuilder<Episode> builder)
        {
            builder.HasKey(e => new { e.Id });
            builder
                .Property(e => e.Id)
                .ValueGeneratedOnAdd();
            builder.HasIndex(e => e.Name).IsUnique();
        }

    }
}
