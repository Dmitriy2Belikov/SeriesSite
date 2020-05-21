using SeriesSite.Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeriesSite.Infrastructure.Services
{
    public interface IAppDataService
    {
        ISerialRepository Series { get; }
        ICountryRepository Countries { get; }
        IGenreRepository Genres { get; }
        void SaveChanges();
    }
}
