namespace codealong180710.Migrations
{
    using codealong180710.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<codealong180710.DataAccessLayer.GarageContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(codealong180710.DataAccessLayer.GarageContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            Vehicle v = new Vehicle() { Name = "Demo Car", Color = "Red", Make = "Demo", Model = "Demo", NrOfWheels = 4, RegNr="DEM001", VehicleType = VehicleType.Car, CheckInTime = DateTime.Now.AddDays(-1)};
            context.Vehicles.AddOrUpdate(x=>x.RegNr,v);
            context.SaveChanges();
        }
    }
}
