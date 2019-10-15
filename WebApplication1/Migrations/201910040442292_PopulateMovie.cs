namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMovie : DbMigration
    {
        public override void Up()
        {Sql("Insert Genres(Genres)values('Fantasy')");
        }
        
        public override void Down()
        {
        }
    }
}
