namespace OnlineCommercialAutomation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InvoiceItemAdjusted : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.InvoiceItems", "Invoices_Id", "dbo.Invoices");
            DropIndex("dbo.InvoiceItems", new[] { "Invoices_Id" });
            RenameColumn(table: "dbo.InvoiceItems", name: "Invoices_Id", newName: "InvoiceId");
            AlterColumn("dbo.InvoiceItems", "InvoiceId", c => c.Int(nullable: false));
            CreateIndex("dbo.InvoiceItems", "InvoiceId");
            AddForeignKey("dbo.InvoiceItems", "InvoiceId", "dbo.Invoices", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.InvoiceItems", "InvoiceId", "dbo.Invoices");
            DropIndex("dbo.InvoiceItems", new[] { "InvoiceId" });
            AlterColumn("dbo.InvoiceItems", "InvoiceId", c => c.Int());
            RenameColumn(table: "dbo.InvoiceItems", name: "InvoiceId", newName: "Invoices_Id");
            CreateIndex("dbo.InvoiceItems", "Invoices_Id");
            AddForeignKey("dbo.InvoiceItems", "Invoices_Id", "dbo.Invoices", "Id");
        }
    }
}
