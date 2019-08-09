namespace GreenToys.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addrentalduration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ToyRents", "RentalDuration", c => c.String(nullable: false));
            AlterColumn("dbo.ToyRents", "UserId", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ToyRents", "UserId", c => c.String());
            DropColumn("dbo.ToyRents", "RentalDuration");
        }
    }
}
