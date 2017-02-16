namespace OrangeBricks.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ViewingRequest : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ViewingRequests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ViewRequestDateTime = c.DateTime(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                        Status = c.Int(nullable: false),
                        Property_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Properties", t => t.Property_Id)
                .Index(t => t.Property_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ViewingRequests", "Property_Id", "dbo.Properties");
            DropIndex("dbo.ViewingRequests", new[] { "Property_Id" });
            DropTable("dbo.ViewingRequests");
        }
    }
}
