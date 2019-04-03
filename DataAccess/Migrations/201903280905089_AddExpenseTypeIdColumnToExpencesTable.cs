namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddExpenseTypeIdColumnToExpencesTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Expenses", "ExpenseType_Id", "dbo.ExpenseTypes");
            DropIndex("dbo.Expenses", new[] { "ExpenseType_Id" });
            RenameColumn(table: "dbo.Expenses", name: "ExpenseType_Id", newName: "ExpenseTypeId");
            AlterColumn("dbo.Expenses", "ExpenseTypeId", c => c.Int(nullable: true));
            CreateIndex("dbo.Expenses", "ExpenseTypeId");
            AddForeignKey("dbo.Expenses", "ExpenseTypeId", "dbo.ExpenseTypes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Expenses", "ExpenseTypeId", "dbo.ExpenseTypes");
            DropIndex("dbo.Expenses", new[] { "ExpenseTypeId" });
            AlterColumn("dbo.Expenses", "ExpenseTypeId", c => c.Int());
            RenameColumn(table: "dbo.Expenses", name: "ExpenseTypeId", newName: "ExpenseType_Id");
            CreateIndex("dbo.Expenses", "ExpenseType_Id");
            AddForeignKey("dbo.Expenses", "ExpenseType_Id", "dbo.ExpenseTypes", "Id");
        }
    }
}
