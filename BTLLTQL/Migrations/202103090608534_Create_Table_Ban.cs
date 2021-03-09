namespace BTLLTQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Create_Table_Ban : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bans",
                c => new
                    {
                        IDBan = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.IDBan);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Bans");
        }
    }
}
