namespace GreenToys.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addtotypeoftoydescription : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TypeOfToys", "ToyDescription", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TypeOfToys", "ToyDescription");
        }
    }
}
