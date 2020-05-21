using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeriesSite.Web.Models
{
    public class SerialViewModel
    {
        public int SerialId { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public string Genres { get; set; }
    }
}
