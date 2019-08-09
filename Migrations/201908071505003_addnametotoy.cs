namespace GreenToys.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addnametotoy : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Toys", "NameOfToy", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Toys", "NameOfToy");
        }
    }
}
