namespace adminlte.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Ticket : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tickets",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        BusID = c.Int(nullable: false),
                        State = c.Boolean(nullable: false),
                        OpenTime = c.DateTime(nullable: false),
                        CloseTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Tickets");
        }
    }
}
