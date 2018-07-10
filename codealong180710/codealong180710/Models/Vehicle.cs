using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace codealong180710.Models
{
    public class Vehicle
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int NrOfWheels { get; set; }
        public string Color { get; set; }
        public string Model { get; set; }
        public string Make { get; set; }
    }
}