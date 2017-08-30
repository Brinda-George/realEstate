namespace RealEstate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class enqu : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EnquiryModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Query = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.EnquiryModels");
        }
    }
}
