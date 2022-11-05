namespace Movie.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DbRefactory : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Session", new[] { "Movie_Id" });
            DropIndex("dbo.Session", new[] { "Room_Id" });
            RenameColumn(table: "dbo.Session", name: "Movie_Id", newName: "MovieId");
            RenameColumn(table: "dbo.Session", name: "Room_Id", newName: "RoomId");
            AlterColumn("dbo.Session", "MovieId", c => c.Guid(nullable: false));
            AlterColumn("dbo.Session", "RoomId", c => c.Guid(nullable: false));
            CreateIndex("dbo.Session", "RoomId");
            CreateIndex("dbo.Session", "MovieId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Session", new[] { "MovieId" });
            DropIndex("dbo.Session", new[] { "RoomId" });
            AlterColumn("dbo.Session", "RoomId", c => c.Guid());
            AlterColumn("dbo.Session", "MovieId", c => c.Guid());
            RenameColumn(table: "dbo.Session", name: "RoomId", newName: "Room_Id");
            RenameColumn(table: "dbo.Session", name: "MovieId", newName: "Movie_Id");
            CreateIndex("dbo.Session", "Room_Id");
            CreateIndex("dbo.Session", "Movie_Id");
        }
    }
}
