namespace OnlineCommercialAutomation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(maxLength: 10, unicode: false),
                        Password = c.String(maxLength: 30, unicode: false),
                        Authority = c.String(maxLength: 1, fixedLength: true, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 30, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 30, unicode: false),
                        Manufacturer = c.String(),
                        Stock = c.Short(nullable: false),
                        PurchasePrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SalePrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IsActive = c.Boolean(nullable: false),
                        ProductImageUrl = c.String(maxLength: 250, unicode: false),
                        CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.SalesTransactions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Amount = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TotalPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Customer_Id = c.Int(),
                        Personal_Id = c.Int(),
                        Product_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.Customer_Id)
                .ForeignKey("dbo.Personals", t => t.Personal_Id)
                .ForeignKey("dbo.Products", t => t.Product_Id)
                .Index(t => t.Customer_Id)
                .Index(t => t.Personal_Id)
                .Index(t => t.Product_Id);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 30, unicode: false),
                        Surname = c.String(maxLength: 30, unicode: false),
                        City = c.String(maxLength: 13, unicode: false),
                        Mail = c.String(maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Personals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 30, unicode: false),
                        Surname = c.String(maxLength: 30, unicode: false),
                        ImageUrl = c.String(maxLength: 250, unicode: false),
                        Departmant_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Departments", t => t.Departmant_Id)
                .Index(t => t.Departmant_Id);
            
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 30, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Expenses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(maxLength: 100, unicode: false),
                        Date = c.DateTime(nullable: false),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.InvoiceItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(maxLength: 100, unicode: false),
                        Amount = c.Int(nullable: false),
                        PricePerUnit = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TotalPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Invoices_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Invoices", t => t.Invoices_Id)
                .Index(t => t.Invoices_Id);
            
            CreateTable(
                "dbo.Invoices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SerialNumber = c.String(maxLength: 1, fixedLength: true, unicode: false),
                        OrderNumber = c.String(maxLength: 6, unicode: false),
                        Date = c.DateTime(nullable: false),
                        TaxOffice = c.String(maxLength: 50, unicode: false),
                        Time = c.DateTime(nullable: false),
                        DeliveredBy = c.String(maxLength: 30, unicode: false),
                        ReceivedBy = c.String(maxLength: 30, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.InvoiceItems", "Invoices_Id", "dbo.Invoices");
            DropForeignKey("dbo.SalesTransactions", "Product_Id", "dbo.Products");
            DropForeignKey("dbo.SalesTransactions", "Personal_Id", "dbo.Personals");
            DropForeignKey("dbo.Personals", "Departmant_Id", "dbo.Departments");
            DropForeignKey("dbo.SalesTransactions", "Customer_Id", "dbo.Customers");
            DropForeignKey("dbo.Products", "CategoryId", "dbo.Categories");
            DropIndex("dbo.InvoiceItems", new[] { "Invoices_Id" });
            DropIndex("dbo.Personals", new[] { "Departmant_Id" });
            DropIndex("dbo.SalesTransactions", new[] { "Product_Id" });
            DropIndex("dbo.SalesTransactions", new[] { "Personal_Id" });
            DropIndex("dbo.SalesTransactions", new[] { "Customer_Id" });
            DropIndex("dbo.Products", new[] { "CategoryId" });
            DropTable("dbo.Invoices");
            DropTable("dbo.InvoiceItems");
            DropTable("dbo.Expenses");
            DropTable("dbo.Departments");
            DropTable("dbo.Personals");
            DropTable("dbo.Customers");
            DropTable("dbo.SalesTransactions");
            DropTable("dbo.Products");
            DropTable("dbo.Categories");
            DropTable("dbo.Admins");
        }
    }
}
