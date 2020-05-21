using SeriesSite.Infrastructure.Models;
using SeriesSite.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeriesSite.Services
{
    public class SerialService : ISerialService
    {
        private IAppDataService _dataService;

        public SerialService(IAppDataService dataService)
        {
            _dataService = dataService;
        }

        public void AddSerial(Serial serial, IEnumerable<string> genres)
        {
            _dataService.Series.Add(serial);

            foreach (var genre in genres)
            {
                var genreObj = _dataService.Genres.GetGenreByName(genre);

                _dataService.Series.AssignGenre(serial, genreObj);
            }

            _dataService.SaveChanges();
        }

        public Serial GetSerial(int id)
        {
            return _dataService.Series.Get(id);
        }

        public IEnumerable<Serial> GetAllSeries()
        {
            return _dataService.Series.GetAll();
        }

        public void DeleteSerial(int id)
        {
            var serial = _dataService.Series.Get(id);

            _dataService.Series.Remove(serial);
            _dataService.Series.RemoveSerialGenres(id);
            _dataService.SaveChanges();
        }

        public IEnumerable<string> GetNamesOfGenres(int id)
        {
            return _dataService.Series.GetGenresNames(id);
        }

        public string GetCountryName(int id)
        {
            return _dataService.Series.GetCountryName(id);
        }

        public IEnumerable<Genre> GetGenresById(int id)
        {
            return _dataService.Series.GetGenresById(id);
        }

        public void EditSerial(int id, string name, IEnumerable<string> genres, int countryId)
        {
            var serial = GetSerial(id);

            serial.Name = name;
            serial.Country = _dataService.Countries.Get(countryId);

            _dataService.Series.RemoveSerialGenres(id);

            foreach (var genre in genres)
            {
                var genreObj = _dataService.Genres.GetGenreByName(genre);
                _dataService.Series.AssignGenre(serial, genreObj);
            }

            _dataService.SaveChanges();
        }
    }
}
