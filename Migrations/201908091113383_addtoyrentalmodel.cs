namespace GreenToys.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addtoyrentalmodel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ToyRents",
                c => new
                    {
                        ToyRentID = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ToyID = c.Int(nullable: false),
                        StartOfRentalDate = c.DateTime(),
                        EndOfRentalDate = c.DateTime(),
                        ScheduledOfRentalDate = c.DateTime(),
                        AdditionalCharge = c.Double(),
                        ToyPrice = c.Double(nullable: false),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ToyRentID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ToyRents");
        }
    }
}
