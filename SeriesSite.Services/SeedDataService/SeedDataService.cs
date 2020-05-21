using Microsoft.EntityFrameworkCore;
using SeriesSite.Infrastructure;
using SeriesSite.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SeriesSite.Services
{
    public class SeedDataService : ISeedDataService
    {
        private readonly AppDbContext _context;

        private readonly List<Genre> _defaultGenres = new List<Genre>
        {
            new Genre() { Name = "Боевик"},
            new Genre() { Name = "Драма" }
        };

        private readonly List<Country> _defaultCountries = new List<Country>()
        {
            new Country() { Name = "США" },
            new Country() { Name = "Россия" }
        };

        public SeedDataService(AppDbContext context)
        {
            _context = context;
        }

        public void Initialise()
        {
            if (_context.Database.GetPendingMigrations().Any())
            {
                _context.Database.Migrate();
            }

            AddGenres();
            AddCountries();
        }

        private void AddGenres()
        {
            if (!_context.Genres.Any())
            {
                _context.Genres.AddRange(_defaultGenres);
                _context.SaveChanges();
            }
        }

        private void AddCountries()
        {
            if (!_context.Countries.Any())
            {
                _context.Countries.AddRange(_defaultCountries);
                _context.SaveChanges();
            }
        }
    }
}
