namespace FootballLeague.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ForeignKeys : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Matches", "GuestId");
            CreateIndex("dbo.Matches", "HostId");
            AddForeignKey("dbo.Matches", "GuestId", "dbo.Teams", "Id", cascadeDelete: false);
            AddForeignKey("dbo.Matches", "HostId", "dbo.Teams", "Id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Matches", "HostId", "dbo.Teams");
            DropForeignKey("dbo.Matches", "GuestId", "dbo.Teams");
            DropIndex("dbo.Matches", new[] { "HostId" });
            DropIndex("dbo.Matches", new[] { "GuestId" });
        }
    }
}
