namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameDescriptionColumnToNameColumnInExpenseTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Expenses", "Name", c => c.String());
            DropColumn("dbo.Expenses", "Description");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Expenses", "Description", c => c.String());
            DropColumn("dbo.Expenses", "Name");
        }
    }
}
