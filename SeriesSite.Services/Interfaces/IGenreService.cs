using SeriesSite.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeriesSite.Services
{
    public interface IGenreService
    {
        IEnumerable<Genre> GetAllGenres();
        Genre GetGenreByName(string name);
    }
}
