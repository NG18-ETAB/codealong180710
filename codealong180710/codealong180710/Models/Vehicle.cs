﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace codealong180710.Models
{
    public class Vehicle
    {
        public int Id { get; set; }
        [Required]
        [StringLength(6,MinimumLength = 6, ErrorMessage = "The Registration number must be 6 characters.")]
        [Display(Name = "Registration number")]
        public string RegNr { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Vehicle type")]
        public VehicleType VehicleType { get; set; }
        [Required]
        [Range(0,20, ErrorMessage = "All vehicles need to have between 0 and 20 wheels.")]
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