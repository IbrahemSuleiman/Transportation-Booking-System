namespace adminlte.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editVehicle : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Vehicles", "Id", "dbo.Buses");
            DropForeignKey("dbo.Vehicles", "company_Id", "dbo.Companies");
            DropForeignKey("dbo.Vehicles", "Id", "dbo.Travels");
            DropForeignKey("dbo.Vehicles", "Id", "dbo.PublicDrivers");
            DropIndex("dbo.Vehicles", new[] { "Id" });
            DropIndex("dbo.Vehicles", new[] { "company_Id" });
            DropPrimaryKey("dbo.Vehicles");
            AddColumn("dbo.Buses", "vehicle_Id", c => c.Int());
            AddColumn("dbo.Travels", "vehicle_Id", c => c.Int());
            AddColumn("dbo.PublicDrivers", "vehicle_Id", c => c.Int());
            AlterColumn("dbo.Vehicles", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Vehicles", "Company_Id", c => c.Int());
            AddPrimaryKey("dbo.Vehicles", "Id");
            CreateIndex("dbo.Buses", "vehicle_Id");
            CreateIndex("dbo.Vehicles", "Company_Id");
            CreateIndex("dbo.Travels", "vehicle_Id");
            CreateIndex("dbo.PublicDrivers", "vehicle_Id");
            AddForeignKey("dbo.Buses", "vehicle_Id", "dbo.Vehicles", "Id");
            AddForeignKey("dbo.Vehicles", "Company_Id", "dbo.Companies", "Id");
            AddForeignKey("dbo.Travels", "vehicle_Id", "dbo.Vehicles", "Id");
            AddForeignKey("dbo.PublicDrivers", "vehicle_Id", "dbo.Vehicles", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PublicDrivers", "vehicle_Id", "dbo.Vehicles");
            DropForeignKey("dbo.Travels", "vehicle_Id", "dbo.Vehicles");
            DropForeignKey("dbo.Vehicles", "Company_Id", "dbo.Companies");
            DropForeignKey("dbo.Buses", "vehicle_Id", "dbo.Vehicles");
            DropIndex("dbo.PublicDrivers", new[] { "vehicle_Id" });
            DropIndex("dbo.Travels", new[] { "vehicle_Id" });
            DropIndex("dbo.Vehicles", new[] { "Company_Id" });
            DropIndex("dbo.Buses", new[] { "vehicle_Id" });
            DropPrimaryKey("dbo.Vehicles");
            AlterColumn("dbo.Vehicles", "Company_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Vehicles", "Id", c => c.Int(nullable: false));
            DropColumn("dbo.PublicDrivers", "vehicle_Id");
            DropColumn("dbo.Travels", "vehicle_Id");
            DropColumn("dbo.Buses", "vehicle_Id");
            AddPrimaryKey("dbo.Vehicles", "Id");
            CreateIndex("dbo.Vehicles", "company_Id");
            CreateIndex("dbo.Vehicles", "Id");
            AddForeignKey("dbo.Vehicles", "Id", "dbo.PublicDrivers", "Id");
            AddForeignKey("dbo.Vehicles", "Id", "dbo.Travels", "Id");
            AddForeignKey("dbo.Vehicles", "company_Id", "dbo.Companies", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Vehicles", "Id", "dbo.Buses", "Id");
        }
    }
}
