namespace QuotesApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedtwocolumns : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Quotes", "Type", c => c.String());
            AddColumn("dbo.Quotes", "CreatedAt", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Quotes", "CreatedAt");
            DropColumn("dbo.Quotes", "Type");
        }
    }
}
