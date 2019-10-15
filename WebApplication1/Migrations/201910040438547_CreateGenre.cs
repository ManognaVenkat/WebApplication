namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateGenre : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Genres = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.movies", "GenreId", c => c.Int(nullable: false));
            CreateIndex("dbo.movies", "GenreId");
            AddForeignKey("dbo.movies", "GenreId", "dbo.Genres", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.movies", "GenreId", "dbo.Genres");
            DropIndex("dbo.movies", new[] { "GenreId" });
            DropColumn("dbo.movies", "GenreId");
            DropTable("dbo.Genres");
        }
    }
}
