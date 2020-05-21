using SeriesSite.Infrastructure.Models;
using SeriesSite.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeriesSite.Services
{
    public class GenreService : IGenreService
    {
        private IAppDataService _dataService;

        public GenreService(IAppDataService dataService)
        {
            _dataService = dataService;
        }

        public IEnumerable<Genre> GetAllGenres()
        {
            return _dataService.Genres.GetAll();
        }

        public Genre GetGenreByName(string name)
        {
            return _dataService.Genres.GetGenreByName(name);
        }
    }
}
