namespace adminlte.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPrivateTrasnportation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrderID = c.String(),
                        Location = c.String(),
                        Distination = c.String(),
                        Time = c.String(),
                        SitNumber = c.Int(nullable: false),
                        Note = c.String(),
                        IDUser = c.String(),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Orders", new[] { "User_Id" });
            DropTable("dbo.Orders");
        }
    }
}
