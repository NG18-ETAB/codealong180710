using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace codealong180710.Models
{
    public class VehicleType
    {
        [Key]
        public int Id { get; set; }
        public string TypeName { get; set; }

        public virtual ICollection<Vehicle> ParkedVehicles { get; set; }

    }
}