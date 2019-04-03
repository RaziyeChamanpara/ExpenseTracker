namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteExpenseTypeIdFromExpensesTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Expenses", "ExpenseTypeId", "dbo.ExpenseTypes");
            DropIndex("dbo.Expenses", new[] { "ExpenseTypeId" });
            RenameColumn(table: "dbo.Expenses", name: "ExpenseTypeId", newName: "ExpenseType_Id");
            AlterColumn("dbo.Expenses", "ExpenseType_Id", c => c.Int());
            CreateIndex("dbo.Expenses", "ExpenseType_Id");
            AddForeignKey("dbo.Expenses", "ExpenseType_Id", "dbo.ExpenseTypes", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Expenses", "ExpenseType_Id", "dbo.ExpenseTypes");
            DropIndex("dbo.Expenses", new[] { "ExpenseType_Id" });
            AlterColumn("dbo.Expenses", "ExpenseType_Id", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Expenses", name: "ExpenseType_Id", newName: "ExpenseTypeId");
            CreateIndex("dbo.Expenses", "ExpenseTypeId");
            AddForeignKey("dbo.Expenses", "ExpenseTypeId", "dbo.ExpenseTypes", "Id", cascadeDelete: true);
        }
    }
}
