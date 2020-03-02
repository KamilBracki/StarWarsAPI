using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace StarWarsTest.Accesslayer.EntityConfiguration
{
    public class CharacterFriendEntityConfiguration : IEntityTypeConfiguration<CharacterFriend>
    {
        public void Configure(EntityTypeBuilder<CharacterFriend> builder)
        {

            builder.HasKey(x => new { x.Id });

            builder
                .Property(i => i.Id)
                .ValueGeneratedOnAdd();

            builder
                .HasOne(ch => ch.Character)
                .WithMany()
                .HasForeignKey(ch => ch.CharacterId).OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(x => x.Friend)
                .WithMany(e => e.CharFriends)
                .HasForeignKey(ch => ch.FriendId);
        }

    }
}
