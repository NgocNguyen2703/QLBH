namespace BTLLTQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Create_Table_QuanLy : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.QuanLys",
                c => new
                    {
                        IDNhanVien = c.String(nullable: false, maxLength: 128),
                        IDBan = c.String(),
                        IDCa = c.String(),
                    })
                .PrimaryKey(t => t.IDNhanVien);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.QuanLys");
        }
    }
}
