﻿namespace OnlineCommercialAutomation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InvoiceAdjusted : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Invoices", "TotalAmount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Invoices", "Time", c => c.String(maxLength: 5, fixedLength: true, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Invoices", "Time", c => c.DateTime(nullable: false));
            DropColumn("dbo.Invoices", "TotalAmount");
        }
    }
}
