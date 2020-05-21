using Microsoft.EntityFrameworkCore;
using System;
using SeriesSite.Infrastructure.Models;

namespace SeriesSite.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Serial> Series { get; set; }
        public DbSet<SerialGenre> SerialGenres { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Country> Countries { get; set; }
    }
}
