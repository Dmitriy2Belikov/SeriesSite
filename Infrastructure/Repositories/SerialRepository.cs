using Microsoft.EntityFrameworkCore;
using SeriesSite.Infrastructure.Models;
using SeriesSite.Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace SeriesSite.Infrastructure.Repositories
{
    public class SerialRepository : Repository<Serial>, ISerialRepository
    {
        private AppDbContext _context;

        public SerialRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<string> GetGenresNames(int id)
        {
            return _context.SerialGenres
                .Include(s => s.Serial)
                .Include(g => g.Genre)
                .Where(s => s.Serial.Id == id)
                .Select(g => g.Genre.Name)
                .ToList();
        }

        public string GetCountryName(int id)
        {
            return _context.Countries.FirstOrDefault(c => c.Id == Get(id).CountryId).Name;
        }

        public void AssignGenre(Serial serial, Genre genre)
        {
            var serialGenre = new SerialGenre()
            {
                Serial = serial,
                Genre = genre
            };

            _context.SerialGenres.Add(serialGenre);
        }

        public void RemoveSerialGenres(int id)
        {
            var serialGenre = _context.SerialGenres
                .Include(s => s.Serial)
                .Where(s => s.Serial.Id == id)
                .ToList();

            _context.SerialGenres.RemoveRange(serialGenre);
        }

        public IEnumerable<Genre> GetGenresById(int id)
        {
            return _context.SerialGenres
                .Include(s => s.Serial)
                .Include(g => g.Genre)
                .Where(s => s.Serial.Id == id)
                .Select(g => g.Genre);
        }
    }
}
