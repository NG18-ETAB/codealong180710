using codealong180710.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace codealong180710.DataAccessLayer
{
    public class GarageContext : DbContext
    {
        public GarageContext() : base("codealong180710")
        {
        }

        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<VehicleType> VehicleTypes { get; set; }
    }
}