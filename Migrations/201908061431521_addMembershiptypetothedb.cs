namespace GreenToys.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addMembershiptypetothedb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MembershipTypes",
                c => new
                    {
                        MembershipTypeID = c.Int(nullable: false, identity: true),
                        MembershipName = c.String(nullable: false),
                        SignUpFree = c.Byte(nullable: false),
                        ChargeRateForOneMonth = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.MembershipTypeID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.MembershipTypes");
        }
    }
}
