namespace OrangeBricks.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Test : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Offers", "UserId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Offers", "UserId");
        }
    }
}
