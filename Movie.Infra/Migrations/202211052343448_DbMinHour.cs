namespace Movie.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DbMinHour : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movie", "Minutes", c => c.Int(nullable: false));
            AddColumn("dbo.Movie", "Hours", c => c.Int(nullable: false));
            DropColumn("dbo.Movie", "Duration");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Movie", "Duration", c => c.DateTime(nullable: false));
            DropColumn("dbo.Movie", "Hours");
            DropColumn("dbo.Movie", "Minutes");
        }
    }
}
