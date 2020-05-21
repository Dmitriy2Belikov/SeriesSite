using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeriesSite.Web.Models
{
    public class SerialEditViewModel
    {
        public int SerialId { get; set; }
        public string Name { get; set; }
        public int? SelectedCountryId { get; set; } = null;
        public List<Select> Countries { get; set; }
        public List<Option> GenreOptions { get; set; }
    }
}
