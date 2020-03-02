using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using StarWarsAPI.Models;
using StarWarsTest.Accesslayer.EntityConfiguration;

namespace StarWarsAPI.AccessLayer
{
    public class StarContext : DbContext
    {
        public StarContext(DbContextOptions<StarContext> options) : base(options)
        {

        }
        public DbSet<Character> Characters { get; set; }
        public DbSet<CharacterEpisode> CharactersEpisodes { get; set; }
        public DbSet<Episode> Episodes { get; set; }
        public DbSet<CharacterFriend> CharaterFriends { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
               .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();

            optionsBuilder
                .UseNpgsql(configuration.GetConnectionString("DefaultConnection"))
                .EnableSensitiveDataLogging();

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CharacterEntityConfiguration());
            modelBuilder.ApplyConfiguration(new CharacterEpisodeEntityConfiguration());
            modelBuilder.ApplyConfiguration(new CharacterFriendEntityConfiguration());
            modelBuilder.ApplyConfiguration(new EpisodeEntityConfiguration());
        }



    }
}
