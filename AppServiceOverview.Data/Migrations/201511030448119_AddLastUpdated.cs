namespace AppServiceOverview.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddLastUpdated : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Teams", "LastUpdated", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Teams", "LastUpdated");
        }
    }
}
