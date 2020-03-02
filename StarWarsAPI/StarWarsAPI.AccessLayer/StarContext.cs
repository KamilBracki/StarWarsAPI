using Microsoft.EntityFrameworkCore;
using StarWarsAPI.Models;
using System;

namespace StarWarsAPI.AccessLayer
{
    public class StarContext : DbContext
    {
        public StarContext(DbContextOptions<StarContext> options) : base(options)
        {

        }

        public DbSet<Character> Characters { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {


        }



    }
}
