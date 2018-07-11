using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace codealong180710.Models
{
    public class IndexViewModel
    {
        public List<IndexVehicle> Vehicles { get; set; }
        public string SearchString { get; set; }
        public string SearchField { get; set; }
    }
}