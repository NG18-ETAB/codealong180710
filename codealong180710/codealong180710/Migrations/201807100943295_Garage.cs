namespace codealong180710.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Garage : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Vehicles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RegNr = c.String(nullable: false, maxLength: 6),
                        Name = c.String(nullable: false),
                        VehicleType = c.Int(nullable: false),
                        NrOfWheels = c.Int(nullable: false),
                        Color = c.String(nullable: false),
                        Model = c.String(nullable: false),
                        Make = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Vehicles");
        }
    }
}
