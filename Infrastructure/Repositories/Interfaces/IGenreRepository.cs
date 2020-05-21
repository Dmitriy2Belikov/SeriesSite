using SeriesSite.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeriesSite.Infrastructure.Repositories.Interfaces
{
    public interface IGenreRepository : IRepository<Genre>
    {
        Genre GetGenreByName(string name);
    }
}
