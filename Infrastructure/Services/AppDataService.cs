using SeriesSite.Infrastructure.Repositories;
using SeriesSite.Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeriesSite.Infrastructure.Services
{
    public class AppDataService : IAppDataService
    {
        private readonly AppDbContext _context;

        private ISerialRepository _series { get; set; }
        private ICountryRepository _countries { get; set; }
        private IGenreRepository _genres { get; set; }

        public AppDataService(AppDbContext context)
        {
            _context = context;
        }

        public ISerialRepository Series
        {
            get
            {
                return _series = new SerialRepository(_context);
            }
        }

        public ICountryRepository Countries
        {
            get
            {
                return _countries = new CountryRepository(_context);
            }
        }

        public IGenreRepository Genres
        {
            get
            {
                return _genres = new GenreRepository(_context);
            }
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
