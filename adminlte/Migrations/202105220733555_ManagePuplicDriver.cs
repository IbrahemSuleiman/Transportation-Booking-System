namespace adminlte.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ManagePuplicDriver : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Passengers", "PassengerID", c => c.String());
            AlterColumn("dbo.PublicDrivers", "PublicDriverID", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PublicDrivers", "PublicDriverID", c => c.Int(nullable: false));
            DropColumn("dbo.Passengers", "PassengerID");
        }
    }
}
