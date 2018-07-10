using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace codealong180710.Models
{
    public class Receipt
    {
        public string RegNr { get; set; }
        public VehicleType VehicleType { get; set; }

        public DateTime CheckInTime { get; set; }
        public DateTime CheckOutTime { get; set; }

        public string TotalTime { get; set; }
        public string TotalPrice { get; set; }


    }
}