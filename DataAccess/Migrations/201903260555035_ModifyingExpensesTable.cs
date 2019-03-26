namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyingExpensesTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Expenses", "Description", c => c.String());
            AddColumn("dbo.Expenses", "DateTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.Expenses", "Amount", c => c.Int(nullable: false));
            AddColumn("dbo.Expenses", "ExpenseType_Id", c => c.Int());
            CreateIndex("dbo.Expenses", "ExpenseType_Id");
            AddForeignKey("dbo.Expenses", "ExpenseType_Id", "dbo.ExpenseTypes", "Id");
            DropColumn("dbo.Expenses", "Title");
            DropColumn("dbo.Expenses", "Cost");
            DropColumn("dbo.Expenses", "ExpenseTypeId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Expenses", "ExpenseTypeId", c => c.Int(nullable: false));
            AddColumn("dbo.Expenses", "Cost", c => c.Int(nullable: false));
            AddColumn("dbo.Expenses", "Title", c => c.String());
            DropForeignKey("dbo.Expenses", "ExpenseType_Id", "dbo.ExpenseTypes");
            DropIndex("dbo.Expenses", new[] { "ExpenseType_Id" });
            DropColumn("dbo.Expenses", "ExpenseType_Id");
            DropColumn("dbo.Expenses", "Amount");
            DropColumn("dbo.Expenses", "DateTime");
            DropColumn("dbo.Expenses", "Description");
        }
    }
}
