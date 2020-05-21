using System;
using System.Collections.Generic;
using System.Text;

namespace SeriesSite.Infrastructure.Models
{
    public class Serial
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<SerialGenre> Genres { get; set; }

        public int? CountryId { get; set; }
        public Country Country { get; set; }
    }
}
