using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace codealong180710.Models
{
    public class EditVehicleViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public List<SelectListItem> VehicleTypes { get; set; }

        [Required]
        [Display(Name = "Vehicle type")]
        public int VehicleTypeId { get; set; }

        [Display(Name = "Owner")]
        public string OwnerName { get; set; }
        public int OwnerId { get; set; }

        [Required]
        [Range(0, 20, ErrorMessage = "All vehicles need to have between 0 and 20 wheels.")]
        [Display(Name = "Number of wheels")]
        public int NrOfWheels { get; set; }
        [Required]
        public string Color { get; set; }
        [Required]
        public string Make { get; set; }
        [Required]
        public string Model { get; set; }
        [Required]
        [Display(Name = "Check in time")]
        public DateTime CheckInTime { get; set; }
    }
}