namespace Movie.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TypeEnumChange : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Session", "TypeAnimation", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Session", "TypeAnimation");
        }
    }
}
