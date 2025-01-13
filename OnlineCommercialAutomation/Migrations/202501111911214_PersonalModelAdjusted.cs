namespace OnlineCommercialAutomation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PersonalModelAdjusted : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Personals", "Departmant_Id", "dbo.Departments");
            DropIndex("dbo.Personals", new[] { "Departmant_Id" });
            RenameColumn(table: "dbo.Personals", name: "Departmant_Id", newName: "DepartmentId");
            AlterColumn("dbo.Personals", "DepartmentId", c => c.Int(nullable: false));
            CreateIndex("dbo.Personals", "DepartmentId");
            AddForeignKey("dbo.Personals", "DepartmentId", "dbo.Departments", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Personals", "DepartmentId", "dbo.Departments");
            DropIndex("dbo.Personals", new[] { "DepartmentId" });
            AlterColumn("dbo.Personals", "DepartmentId", c => c.Int());
            RenameColumn(table: "dbo.Personals", name: "DepartmentId", newName: "Departmant_Id");
            CreateIndex("dbo.Personals", "Departmant_Id");
            AddForeignKey("dbo.Personals", "Departmant_Id", "dbo.Departments", "Id");
        }
    }
}
