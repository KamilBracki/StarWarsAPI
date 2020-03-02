using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StarWarsAPI.Models;

namespace StarWarsTest.Accesslayer.EntityConfiguration
{
    public class CharacterEpisodeEntityConfiguration : IEntityTypeConfiguration<CharacterEpisode>
    {
        public void Configure(EntityTypeBuilder<CharacterEpisode> builder)
        {
            builder.HasKey(ce => new { ce.Id });
            builder.Property(ce => ce.Id).ValueGeneratedOnAdd();





        }

    }
}
