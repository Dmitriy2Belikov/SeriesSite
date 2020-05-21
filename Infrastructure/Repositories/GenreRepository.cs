using SeriesSite.Infrastructure.Models;
using SeriesSite.Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace SeriesSite.Infrastructure.Repositories
{
    public class GenreRepository : Repository<Genre>, IGenreRepository
    {
        private AppDbContext _context;

        public GenreRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public Genre GetGenreByName(string name)
        {
            return _context.Genres.FirstOrDefault(g => g.Name == name);
        }
    }
}
