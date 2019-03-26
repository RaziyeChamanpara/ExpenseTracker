namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeDataTimeCloumnToDataInEpensesTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Expenses", "Date", c => c.DateTime(nullable: false));
            DropColumn("dbo.Expenses", "DateTime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Expenses", "DateTime", c => c.DateTime(nullable: false));
            DropColumn("dbo.Expenses", "Date");
        }
    }
}
