namespace GreenToys.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class membershipsignup : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MembershipTypes", "SignUp", c => c.Byte(nullable: false));
            DropColumn("dbo.MembershipTypes", "SignUpFree");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MembershipTypes", "SignUpFree", c => c.Byte(nullable: false));
            DropColumn("dbo.MembershipTypes", "SignUp");
        }
    }
}
