using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace codealong180710.Models
{
    public class IndexVehicle
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Display(Name = "Vehicle type")]
        public VehicleType VehicleType { get; set; }
        [Display(Name = "Registration number")]
        public string RegNr { get; set; }
        public string Color { get; set; }
        [Display(Name="Check in time")]
        public DateTime CheckInTime { get; set; }
    }
}