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

            List<Member> members = new List<Member>();
            members.Add(new Member()
            {
                FirstName = "Amer",
                LastName = "Olof",
                BirthDay = DateTime.Now.AddYears(-22),
                SocialSecNr = "19960711-1337",
                EMail = "Yvette@Baryali.Ehab",
                Adress = "Ravicandra 13",
                PhoneNr = "08500843"
            });
            members.Add(new Member()
            {
                FirstName = "Zafar",
                LastName = "Awras",
                BirthDay = DateTime.Now.AddDays(-90509),
                SocialSecNr = "18830212-8008",
                EMail = "Linda@Ahmed.Naji",
                Adress = "Cathy 101",
                PhoneNr = "09031056"
            });
            foreach(var m in members)
            {
                context.Members.AddOrUpdate(x => x.SocialSecNr, m);
            }
            context.SaveChanges();

            Vehicle v = new Vehicle()
            {
                Name = "Demo Car",
                Color = "Red",
                Make = "Demo",
                Model = "Demo",
                NrOfWheels = 4,
                RegNr = "DEM001",
                VehicleTypeId = context.VehicleTypes.First(x => x.TypeName == "Car").Id,
                MemberId = context.Members.First().Id,
                CheckInTime = DateTime.Now.AddDays(-1)
            };
            context.Vehicles.AddOrUpdate(x => x.RegNr, v);
            context.SaveChanges();
        }
    }
}
