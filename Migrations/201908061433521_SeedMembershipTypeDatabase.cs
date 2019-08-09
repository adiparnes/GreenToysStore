namespace GreenToys.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedMembershipTypeDatabase : DbMigration
    {
        public override void Up()//create sql statment--()-col names
        {
         
            Sql("INSERT INTO [dbo].[MembershipTypes](MembershipName,SignUp,ChargeRateForOneMonth) VALUES('Member',100,25)");
            Sql("INSERT INTO [dbo].[MembershipTypes](MembershipName,SignUp,ChargeRateForOneMonth) VALUES('Admin',0,0)");
        }
        
        public override void Down()
        {
        }
    }
}
