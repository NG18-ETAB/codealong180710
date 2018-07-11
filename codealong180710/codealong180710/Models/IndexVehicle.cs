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
        [Display(Name = "Registration Number")]
        public string RegNr { get; set; }
        public string Color { get; set; }
        [Required]
        [Display(Name = "Check In Time" )]
        public DateTime CheckInTime { get; set; }
        public object VehicleType { get; internal set; }
    }
}