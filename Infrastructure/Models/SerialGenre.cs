using System;
using System.Collections.Generic;
using System.Text;

namespace SeriesSite.Infrastructure.Models
{
    public class SerialGenre
    {
        public int Id { get; set; }
        public Serial Serial { get; set; }
        public Genre Genre { get; set; }
    }
}
