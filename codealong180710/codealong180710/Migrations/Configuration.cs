namespace codealong180710.Migrations
{
    using codealong180710.Models;
    using System;
    using System.Collections.Generic;
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

            List<VehicleType> types = new List<VehicleType>();
            types.Add(new VehicleType() { TypeName = "Car" });
            types.Add(new VehicleType() { TypeName = "Boat" });
            types.Add(new VehicleType() { TypeName = "Bus" });
            types.Add(new VehicleType() { TypeName = "Motorcycle" });
            types.Add(new VehicleType() { TypeName = "Airplane" });
            foreach (var temp in types)
            {
                context.VehicleTypes.AddOrUpdate(x => x.TypeName, temp);
            }
            context.SaveChanges();

        }
    }
}
