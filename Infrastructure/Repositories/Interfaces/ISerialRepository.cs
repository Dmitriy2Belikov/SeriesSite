using SeriesSite.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeriesSite.Infrastructure.Repositories.Interfaces
{
    public interface ISerialRepository : IRepository<Serial>
    {
        IEnumerable<string> GetGenresNames(int id);
        string GetCountryName(int id);
        void AssignGenre(Serial serial, Genre genre);
        void RemoveSerialGenres(int id);
        IEnumerable<Genre> GetGenresById(int id);
    }
}
