namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Membership : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Customers", "member_ID", "dbo.MembershipTypes");
            DropForeignKey("dbo.Customers", "MembershipId_ID", "dbo.MembershipTypes");
            DropIndex("dbo.Customers", new[] { "member_ID" });
            DropIndex("dbo.Customers", new[] { "MembershipId_ID" });
            DropColumn("dbo.Customers", "member_ID");
            DropColumn("dbo.Customers", "MembershipId_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "MembershipId_ID", c => c.Int());
            AddColumn("dbo.Customers", "member_ID", c => c.Int());
            CreateIndex("dbo.Customers", "MembershipId_ID");
            CreateIndex("dbo.Customers", "member_ID");
            AddForeignKey("dbo.Customers", "MembershipId_ID", "dbo.MembershipTypes", "ID");
            AddForeignKey("dbo.Customers", "member_ID", "dbo.MembershipTypes", "ID");
        }
    }
}
