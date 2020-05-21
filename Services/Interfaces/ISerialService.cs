using SeriesSite.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeriesSite.Services
{
    public interface ISerialService
    {
        void AddSerial(Serial serial, IEnumerable<string> genres);
        Serial GetSerial(int id);
        IEnumerable<Serial> GetAllSeries();
        void DeleteSerial(int id);
        IEnumerable<string> GetNamesOfGenres(int id);
        string GetCountryName(int id);
        void EditSerial(int id, string name, IEnumerable<string> genres, int countryId);
    }
}
