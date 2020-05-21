using SeriesSite.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeriesSite.Services
{
    public interface ICountryService
    {
        Country GetCountryByName(string name);
        Country GetCountryById(int id);
        IEnumerable<Country> GetAllCountries();
    }
}
