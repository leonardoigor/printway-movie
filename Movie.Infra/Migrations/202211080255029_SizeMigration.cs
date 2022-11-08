namespace Movie.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SizeMigration : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Movie", "Image", c => c.String(maxLength: 1000, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Movie", "Image", c => c.String(maxLength: 100, unicode: false));
        }
    }
}
