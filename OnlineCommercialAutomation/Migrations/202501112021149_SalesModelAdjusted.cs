namespace OnlineCommercialAutomation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SalesModelAdjusted : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SalesTransactions", "Product_Id", "dbo.Products");
            DropForeignKey("dbo.SalesTransactions", "Customer_Id", "dbo.Customers");
            DropForeignKey("dbo.SalesTransactions", "Personal_Id", "dbo.Personals");
            DropIndex("dbo.SalesTransactions", new[] { "Customer_Id" });
            DropIndex("dbo.SalesTransactions", new[] { "Personal_Id" });
            DropIndex("dbo.SalesTransactions", new[] { "Product_Id" });
            RenameColumn(table: "dbo.SalesTransactions", name: "Product_Id", newName: "ProductId");
            RenameColumn(table: "dbo.SalesTransactions", name: "Customer_Id", newName: "CustomerId");
            RenameColumn(table: "dbo.SalesTransactions", name: "Personal_Id", newName: "PersonalId");
            AlterColumn("dbo.SalesTransactions", "CustomerId", c => c.Int(nullable: false));
            AlterColumn("dbo.SalesTransactions", "PersonalId", c => c.Int(nullable: false));
            AlterColumn("dbo.SalesTransactions", "ProductId", c => c.Int(nullable: false));
            CreateIndex("dbo.SalesTransactions", "ProductId");
            CreateIndex("dbo.SalesTransactions", "CustomerId");
            CreateIndex("dbo.SalesTransactions", "PersonalId");
            AddForeignKey("dbo.SalesTransactions", "ProductId", "dbo.Products", "Id", cascadeDelete: true);
            AddForeignKey("dbo.SalesTransactions", "CustomerId", "dbo.Customers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.SalesTransactions", "PersonalId", "dbo.Personals", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SalesTransactions", "PersonalId", "dbo.Personals");
            DropForeignKey("dbo.SalesTransactions", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.SalesTransactions", "ProductId", "dbo.Products");
            DropIndex("dbo.SalesTransactions", new[] { "PersonalId" });
            DropIndex("dbo.SalesTransactions", new[] { "CustomerId" });
            DropIndex("dbo.SalesTransactions", new[] { "ProductId" });
            AlterColumn("dbo.SalesTransactions", "ProductId", c => c.Int());
            AlterColumn("dbo.SalesTransactions", "PersonalId", c => c.Int());
            AlterColumn("dbo.SalesTransactions", "CustomerId", c => c.Int());
            RenameColumn(table: "dbo.SalesTransactions", name: "PersonalId", newName: "Personal_Id");
            RenameColumn(table: "dbo.SalesTransactions", name: "CustomerId", newName: "Customer_Id");
            RenameColumn(table: "dbo.SalesTransactions", name: "ProductId", newName: "Product_Id");
            CreateIndex("dbo.SalesTransactions", "Product_Id");
            CreateIndex("dbo.SalesTransactions", "Personal_Id");
            CreateIndex("dbo.SalesTransactions", "Customer_Id");
            AddForeignKey("dbo.SalesTransactions", "Personal_Id", "dbo.Personals", "Id");
            AddForeignKey("dbo.SalesTransactions", "Customer_Id", "dbo.Customers", "Id");
            AddForeignKey("dbo.SalesTransactions", "Product_Id", "dbo.Products", "Id");
        }
    }
}
