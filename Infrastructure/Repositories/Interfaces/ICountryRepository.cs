using SeriesSite.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeriesSite.Infrastructure.Repositories.Interfaces
{
    public interface ICountryRepository : IRepository<Country>
    {
        Country GetCountryByName(string name);
    }
}
