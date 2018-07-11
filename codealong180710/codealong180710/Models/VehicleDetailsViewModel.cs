using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace codealong180710.Models
{
    public class VehicleDetailsViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Registration number")]
        public string RegNr { get; set; }

        public string Name { get; set; }

        [Display(Name = "Number of wheels")]
        public int NrOfWheels { get; set; }

        public string Color { get; set; }

        public string Model { get; set; }

        public string Make { get; set; }

        [Display(Name = "Check in time")]
        public DateTime CheckInTime { get; set; }

        [Display(Name = "Vehicle type")]
        public string VehicleType { get; set; }

        [Display(Name = "Owner")]
        public string OwnerName { get; set; }
    }
}