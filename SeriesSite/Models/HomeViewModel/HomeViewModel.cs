using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeriesSite.Web.Models.HomeViewModel
{
    public class HomeViewModel
    {
        public IEnumerable<SerialViewModel> SerialViewModels { get; set; }
    }
}
