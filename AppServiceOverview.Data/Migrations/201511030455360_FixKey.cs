namespace AppServiceOverview.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixKey : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Teams");
            AlterColumn("dbo.Teams", "Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Teams", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Teams");
            AlterColumn("dbo.Teams", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Teams", "Id");
        }
    }
}
