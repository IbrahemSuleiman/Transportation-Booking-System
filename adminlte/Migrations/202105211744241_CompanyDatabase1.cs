namespace adminlte.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CompanyDatabase1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Companies", "CompanyID", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Companies", "CompanyID", c => c.Int(nullable: false));
        }
    }
}
