namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Genres", "GenreType", c => c.String());
            DropColumn("dbo.Genres", "Genres");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Genres", "Genres", c => c.String());
            DropColumn("dbo.Genres", "GenreType");
        }
    }
}
