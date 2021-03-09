namespace BTLLTQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Create_Table_Ca : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cas",
                c => new
                    {
                        IDCa = c.String(nullable: false, maxLength: 128),
                        Ngay = c.String(),
                    })
                .PrimaryKey(t => t.IDCa);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Cas");
        }
    }
}
