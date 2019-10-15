namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMembership : DbMigration
    {
        public override void Up()
        {
            Sql("Insert MembershipTypes(Type,Duration,SignupFee,Discount) values('Yearly',12,1200,20)");
            Sql("Insert MembershipTypes(Type,Duration,SignupFee,Discount) values('Half-Yearly',9,600,10)");
            Sql("Insert MembershipTypes(Type,Duration,SignupFee,Discount) values('Quarterly',2,300,5)");
            Sql("Insert MembershipTypes(Type,Duration,SignupFee,Discount) values('PayAsyouGo',0,0,0)");
        }
        
        public override void Down()
        {
        }
    }
}
