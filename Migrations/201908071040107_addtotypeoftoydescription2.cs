namespace GreenToys.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addtotypeoftoydescription2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Toys", "ToyDescription", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Toys", "ToyDescription");
        }
    }
}
