namespace OnlineCommercialAutomation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdjustDepartmentModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Departments", "isActive", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Departments", "isActive");
        }
    }
}
