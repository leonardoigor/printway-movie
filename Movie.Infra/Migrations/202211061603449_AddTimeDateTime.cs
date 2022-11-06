namespace Movie.Infra.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AddTimeDateTime : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Session", "StartDate");
            DropColumn("dbo.Session", "EndDate");
            AddColumn("dbo.Session", "StartDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Session", "EndDate", c => c.DateTime(nullable: false));
            // AlterColumn("dbo.Session", "StartDate", c => c.DateTime(nullable: false));
            // AlterColumn("dbo.Session", "EndDate", c => c.DateTime(nullable: false));
        }

        public override void Down()
        {
            AlterColumn("dbo.Session", "EndDate", c => c.String(maxLength: 100, unicode: false));
            AlterColumn("dbo.Session", "StartDate", c => c.String(maxLength: 100, unicode: false));
        }
    }
}
