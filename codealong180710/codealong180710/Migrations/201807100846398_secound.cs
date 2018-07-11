namespace codealong180710.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class secound : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Vehicles", "RegNr", c => c.String(nullable: false, maxLength: 6));
            AlterColumn("dbo.Vehicles", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Vehicles", "Color", c => c.String(nullable: false));
            AlterColumn("dbo.Vehicles", "Model", c => c.String(nullable: false));
            AlterColumn("dbo.Vehicles", "Make", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Vehicles", "Make", c => c.String());
            AlterColumn("dbo.Vehicles", "Model", c => c.String());
            AlterColumn("dbo.Vehicles", "Color", c => c.String());
            AlterColumn("dbo.Vehicles", "Name", c => c.String());
            AlterColumn("dbo.Vehicles", "RegNr", c => c.String());
        }
    }
}
