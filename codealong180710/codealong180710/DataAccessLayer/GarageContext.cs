using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using codealong180710.Models;

namespace codealong180710.DataAccessLayer
{
    public class GarageContext : DbContext
    {

        public GarageContext() : base("GarageCodeAlong180710")
        {

        }

        public DbSet<Vehicle> Vehicles { get; set; }
    }
}