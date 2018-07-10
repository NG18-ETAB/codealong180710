using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace codealong180710.Models
{
    public class ParkVehicleViewModel
    {
        [Required]
        [StringLength(6, MinimumLength = 6, ErrorMessage = "The Registration Number Must Be 6 Characters")]
        [Display(Name = "Registration number")]
        public string RegNr { get; set; }
        [Required]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Vehicle Type")]
        public VehicleType VehicleType { get; set; }

        [Range(0, 20, ErrorMessage = "0-20 wheels.. please.. \t Try Again")]
        [Display(Name = "Number of Wheels")]
        [Required]
        public int NrOfWheels { get; set; }
        [Required]
        public string Color { get; set; }
        [Required]
        public string Model { get; set; }
        [Required]
        public string Make { get; set; }

        public string ErrorMessage { get; set; }

    }
}