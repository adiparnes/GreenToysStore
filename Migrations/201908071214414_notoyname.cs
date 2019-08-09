namespace GreenToys.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class notoyname : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Toys", "ToyName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Toys", "ToyName", c => c.String(nullable: false));
        }
    }
}
