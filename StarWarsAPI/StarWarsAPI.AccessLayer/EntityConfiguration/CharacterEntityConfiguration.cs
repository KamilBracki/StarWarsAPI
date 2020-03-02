using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace StarWarsTest.Accesslayer.EntityConfiguration
{
    public class CharacterEntityConfiguration : IEntityTypeConfiguration<Character>
    {
        public void Configure(EntityTypeBuilder<Character> builder)
        {
            builder.HasKey(x => new { x.Id });

            builder
                .Property(i => i.Id)
                .ValueGeneratedOnAdd();
        }
    
    }
}
