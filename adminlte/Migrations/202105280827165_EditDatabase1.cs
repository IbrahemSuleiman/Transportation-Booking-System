namespace adminlte.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditDatabase1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Vehicles", "VehicleID", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Vehicles", "VehicleID", c => c.Int(nullable: false));
        }
    }
}
