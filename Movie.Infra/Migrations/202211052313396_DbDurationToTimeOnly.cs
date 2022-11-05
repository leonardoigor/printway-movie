namespace Movie.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DbDurationToTimeOnly : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Movie", "Duration");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Movie", "Duration", c => c.DateTime(nullable: false));
        }
    }
}
