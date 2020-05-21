using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SeriesSite.Infrastructure.Models;
using SeriesSite.Services;
using SeriesSite.Web.Models;
using SeriesSite.Web.Models.HomeViewModel;

namespace SeriesSite.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ISerialService _serialService;
        private ICountryService _countryService;
        private IGenreService _genreService;

        public HomeController(ILogger<HomeController> logger, ISerialService serialService, 
            ICountryService countryService, IGenreService genreService)
        {
            _logger = logger;
            _serialService = serialService;
            _countryService = countryService;
            _genreService = genreService;
        }

        public IActionResult Index()
        {
            var series = _serialService.GetAllSeries();

            var serialViewModels = series.Select(s => new SerialViewModel()
            {
                SerialId = s.Id,
                Name = s.Name,
                Country = _serialService.GetCountryName(s.Id),
                Genres = string.Join(", ", _serialService.GetNamesOfGenres(s.Id))
            });

            var homeViewModel = new HomeViewModel()
            {
                SerialViewModels = serialViewModels
            };

            return View(homeViewModel);
        }

        [HttpGet]
        public IActionResult AddSerial()
        {
            var genres = _genreService.GetAllGenres();
            var countries = _countryService.GetAllCountries();

            var serialViewModel = new SerialRegistrationViewModel()
            {
                Countries = countries.Select(c => new Select() { Name = c.Name, Id = c.Id}).ToList(),
                GenreOptions = genres.Select(g => new Option() { Name = g.Name }).ToList()
            };

            return View(serialViewModel);
        }

        [HttpPost]
        public IActionResult AddSerial(SerialRegistrationViewModel serialModel)
        {
            var genres = serialModel.GenreOptions
                .Where(g => g.IsSelected)
                .Select(g => g.Name);

            if (ModelState.IsValid && genres.Count() > 0)
            {
                var serial = new Serial()
                {
                    Id = serialModel.SerialId,
                    Name = serialModel.Name,
                    Country = _countryService.GetCountryById((int)serialModel.SelectedCountryId)
                };

                _serialService.AddSerial(serial, genres);

                return RedirectToAction("Index", "Home");
            }
            else
            {
                var countries = _countryService.GetAllCountries();

                serialModel.Countries = countries.Select(c => new Select() { Name = c.Name, Id = c.Id }).ToList();

                return View(serialModel);
            }
        }

        [HttpGet]
        public IActionResult DeleteSerial(int id)
        {
            _serialService.DeleteSerial(id);

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult EditSerial(int id)
        {
            var serial = _serialService.GetSerial(id);
            var serialGenres = _serialService.GetNamesOfGenres(id);
            var genres = _genreService.GetAllGenres();

            var serialModel = new SerialEditViewModel()
            {
                SerialId = serial.Id,
                Name = serial.Name,
                SelectedCountryId = serial.CountryId,
                Countries = _countryService.GetAllCountries().Select(c => new Select() { Name = c.Name, Id = c.Id }).ToList(),
                GenreOptions = genres.Select(g => new Option() { Name = g.Name, IsSelected = serialGenres.Contains(g.Name) }).ToList()
            };

            return View(serialModel);
        }

        [HttpPost]
        public IActionResult EditSerial(int id, SerialEditViewModel serialModel)
        {
            var genres = serialModel.GenreOptions
                .Where(g => g.IsSelected)
                .Select(g => g.Name);

            if (ModelState.IsValid && genres.Count() > 0)
            {
                var selectedGenres = serialModel.GenreOptions.Where(g => g.IsSelected).Select(g => g.Name);

                _serialService.EditSerial(id, serialModel.Name, selectedGenres, (int)serialModel.SelectedCountryId);

                return RedirectToAction("Index", "Home");
            }
            else
            {
                var countries = _countryService.GetAllCountries();

                serialModel.Countries = countries.Select(c => new Select() { Name = c.Name, Id = c.Id }).ToList();

                return View(serialModel);
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
