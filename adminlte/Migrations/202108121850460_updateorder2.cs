namespace adminlte.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateorder2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tickets", "DriverID", c => c.Int(nullable: false));
            AddColumn("dbo.Tickets", "OrderID", c => c.Int(nullable: false));
            DropColumn("dbo.Tickets", "UserID");
            DropColumn("dbo.Tickets", "BusID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tickets", "BusID", c => c.Int(nullable: false));
            AddColumn("dbo.Tickets", "UserID", c => c.Int(nullable: false));
            DropColumn("dbo.Tickets", "OrderID");
            DropColumn("dbo.Tickets", "DriverID");
        }
    }
}
