namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddExpenseTypeNamePropertyToExpenseModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Expenses", "ExpenseTypeName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Expenses", "ExpenseTypeName");
        }
    }
}
