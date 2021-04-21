namespace BTLLTQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Tb : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.CheckAcounts", newName: "CheckAccounts");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.CheckAccounts", newName: "CheckAcounts");
        }
    }
}
