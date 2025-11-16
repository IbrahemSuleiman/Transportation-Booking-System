namespace adminlte.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CompanyDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CompanyID = c.Int(nullable: false),
                        CompanyName = c.String(),
                        CompanyLocation = c.String(),
                        CompanyFax = c.String(),
                        CompanyTelePhone = c.String(),
                        AboutCompany = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Vehicles",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        VehicleID = c.Int(nullable: false),
                        IDCompany = c.Int(nullable: false),
                        IDBus = c.Int(nullable: false),
                        IDPublicDriver = c.Int(nullable: false),
                        IDTravel = c.Int(nullable: false),
                        company_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Buses", t => t.Id)
                .ForeignKey("dbo.Companies", t => t.company_Id, cascadeDelete: true)
                .ForeignKey("dbo.PublicDrivers", t => t.Id)
                .ForeignKey("dbo.Travels", t => t.Id)
                .Index(t => t.Id)
                .Index(t => t.company_Id);
            
            CreateTable(
                "dbo.Buses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BusID = c.String(),
                        BusModel = c.String(),
                        BusPlate = c.String(),
                        BusColor = c.String(),
                        BusNumber = c.String(),
                        IDVehicle = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PublicDrivers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PublicDriverID = c.Int(nullable: false),
                        DriverName = c.String(),
                        DriverLastName = c.String(),
                        DriverNationalID = c.String(),
                        DriverPhone = c.String(),
                        DriverImage = c.String(),
                        IDVehicle = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Travels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TravelID = c.Int(nullable: false),
                        Location = c.String(),
                        Destination = c.String(),
                        Leavetime = c.String(),
                        Notes = c.String(),
                        IDCompany = c.Int(nullable: false),
                        IDPassenger = c.Int(nullable: false),
                        IDVehicle = c.Int(nullable: false),
                        company_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Companies", t => t.company_Id)
                .Index(t => t.company_Id);
            
            CreateTable(
                "dbo.Passengers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SitNumber = c.String(),
                        IDUser = c.String(),
                        IDTravel = c.Int(nullable: false),
                        IDCompany = c.Int(nullable: false),
                        User_Id = c.String(maxLength: 128),
                        Travel_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .ForeignKey("dbo.Travels", t => t.Travel_Id)
                .Index(t => t.User_Id)
                .Index(t => t.Travel_Id);
            
            AddColumn("dbo.Clients", "IDUser", c => c.String(nullable: false));
            DropColumn("dbo.Clients", "UserID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Clients", "UserID", c => c.String());
            DropForeignKey("dbo.Vehicles", "Id", "dbo.Travels");
            DropForeignKey("dbo.Passengers", "Travel_Id", "dbo.Travels");
            DropForeignKey("dbo.Passengers", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Travels", "company_Id", "dbo.Companies");
            DropForeignKey("dbo.Vehicles", "Id", "dbo.PublicDrivers");
            DropForeignKey("dbo.Vehicles", "company_Id", "dbo.Companies");
            DropForeignKey("dbo.Vehicles", "Id", "dbo.Buses");
            DropIndex("dbo.Passengers", new[] { "Travel_Id" });
            DropIndex("dbo.Passengers", new[] { "User_Id" });
            DropIndex("dbo.Travels", new[] { "company_Id" });
            DropIndex("dbo.Vehicles", new[] { "company_Id" });
            DropIndex("dbo.Vehicles", new[] { "Id" });
            DropColumn("dbo.Clients", "IDUser");
            DropTable("dbo.Passengers");
            DropTable("dbo.Travels");
            DropTable("dbo.PublicDrivers");
            DropTable("dbo.Buses");
            DropTable("dbo.Vehicles");
            DropTable("dbo.Companies");
        }
    }
}
