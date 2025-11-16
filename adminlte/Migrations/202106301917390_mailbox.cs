namespace adminlte.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mailbox : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MailBoxes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Message = c.String(),
                        Subject = c.String(),
                        TimeStamp = c.String(),
                        Sender = c.String(),
                        SenderID = c.String(),
                        TargetID = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.MailBoxes");
        }
    }
}
