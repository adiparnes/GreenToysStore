namespace GreenToys.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adddisabletoidentity : DbMigration
    {
        public override void Up()
        {
           // AddColumn("dbo.AspNetUsers", "Disable", c => c.Int(nullable: false));
            //AddColumn("dbo.AspNetUsers", "BirthDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.AspNetUsers", "BirthDate");
          //  DropColumn("dbo.AspNetUsers", "Disabe");
            DropColumn("dbo.AspNetUsers", "Disable");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "BirthDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.AspNetUsers", "Disabe", c => c.Int(nullable: false));
            AddColumn("dbo.AspNetUsers", "Disable", c => c.Int(nullable: false));
           // DropColumn("dbo.AspNetUsers", "BirthDate");
            //DropColumn("dbo.AspNetUsers", "Disable");
        }
    }
}
