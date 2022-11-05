namespace Movie.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Movie",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Image = c.String(maxLength: 100, unicode: false),
                        Title = c.String(maxLength: 100, unicode: false),
                        Description = c.String(maxLength: 100, unicode: false),
                        Duration = c.Time(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Room",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(maxLength: 100, unicode: false),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Session",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Date = c.DateTime(nullable: false),
                        StartDate = c.String(maxLength: 100, unicode: false),
                        EndDate = c.String(maxLength: 100, unicode: false),
                        Price = c.Double(nullable: false),
                        IsDubbed = c.Boolean(nullable: false),
                        Movie_Id = c.Guid(),
                        Room_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Movie", t => t.Movie_Id)
                .ForeignKey("dbo.Room", t => t.Room_Id)
                .Index(t => t.Movie_Id)
                .Index(t => t.Room_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Session", "Room_Id", "dbo.Room");
            DropForeignKey("dbo.Session", "Movie_Id", "dbo.Movie");
            DropIndex("dbo.Session", new[] { "Room_Id" });
            DropIndex("dbo.Session", new[] { "Movie_Id" });
            DropTable("dbo.Session");
            DropTable("dbo.Room");
            DropTable("dbo.Movie");
        }
    }
}
