using System;
using System.Collections.Generic;
using System.Text;

namespace SeriesSite.Infrastructure.Models
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Serial> Series { get; set; }
    }
}
