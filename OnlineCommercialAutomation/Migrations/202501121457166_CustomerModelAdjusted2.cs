namespace OnlineCommercialAutomation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CustomerModelAdjusted2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "Surname", c => c.String(nullable: false, maxLength: 30, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "Surname", c => c.String(maxLength: 30, unicode: false));
        }
    }
}
