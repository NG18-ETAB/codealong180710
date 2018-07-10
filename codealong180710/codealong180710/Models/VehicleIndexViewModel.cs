using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace codealong180710.Models
{
    public class VehicleIndexViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Display(Name = "Registration Number")]
        public string RegNr { get; set; }
        public string Color { get; set; }
    }
}