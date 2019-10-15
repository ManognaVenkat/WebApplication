namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Movies : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.movies",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        MovieName = c.String(),
                        theatre = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.movies");
        }
    }
}
