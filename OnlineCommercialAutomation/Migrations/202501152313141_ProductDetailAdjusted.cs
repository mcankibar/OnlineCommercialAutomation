namespace OnlineCommercialAutomation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProductDetailAdjusted : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProductDetails", "Comment", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ProductDetails", "Comment");
        }
    }
}
