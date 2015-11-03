namespace AppServiceOverview.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTeamTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Teams",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Rank = c.Int(nullable: false),
                        Name = c.String(),
                        NextMatch = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Teams");
        }
    }
}
