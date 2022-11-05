namespace Movie.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DbDurationToTime : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movie", "Duration", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movie", "Duration");
        }
    }
}
