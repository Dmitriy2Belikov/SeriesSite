using System;
using System.Collections.Generic;
using System.Text;

namespace SeriesSite.Infrastructure.Models
{
    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<SerialGenre> Series { get; set; }
    }
}
