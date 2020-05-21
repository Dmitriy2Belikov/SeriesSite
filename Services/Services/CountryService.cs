using SeriesSite.Infrastructure.Models;
using SeriesSite.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeriesSite.Services
{
    public class CountryService : ICountryService
    {
        private IAppDataService _dataService;

        public CountryService(IAppDataService dataService)
        {
            _dataService = dataService;
        }

        public Country GetCountryByName(string name)
        {
            return _dataService.Countries.GetCountryByName(name);
        }

        public Country GetCountryById(int id)
        {
            return _dataService.Countries.Get(id);
        }

        public IEnumerable<Country> GetAllCountries()
        {
            return _dataService.Countries.GetAll();
        }
    }
}
