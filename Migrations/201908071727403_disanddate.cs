namespace GreenToys.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class disanddate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Disable", c => c.Int(nullable: false));
            AddColumn("dbo.AspNetUsers", "BirthDate", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Disable");
            DropColumn("dbo.AspNetUsers", "BirthDate");
        }
    }
}
