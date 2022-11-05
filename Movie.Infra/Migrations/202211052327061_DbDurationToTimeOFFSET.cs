namespace Movie.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DbDurationToTimeOFFSET : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Movie", "Duration", c => c.DateTimeOffset(nullable: false, precision: 7));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Movie", "Duration", c => c.DateTime(nullable: false));
        }
    }
}
