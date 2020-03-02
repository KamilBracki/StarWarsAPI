using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

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
