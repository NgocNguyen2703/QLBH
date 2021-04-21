namespace BTLLTQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Create_Table_CheckAccount : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CheckAccounts",
                c => new
                    {
                        CheckUsername = c.String(nullable: false, maxLength: 128),
                        CheckPassword = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.CheckUsername);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CheckAccounts");
        }
    }
}
