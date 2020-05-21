using Microsoft.EntityFrameworkCore;
using SeriesSite.Infrastructure.Models;
using SeriesSite.Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SeriesSite.Infrastructure.Repositories
{
    class CountryRepository : Repository<Country>, ICountryRepository
    {
        private AppDbContext _context;

        public CountryRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public Country GetCountryByName(string name)
        {
            return _context.Countries.FirstOrDefault(c => c.Name == name);
        }
    }
}
