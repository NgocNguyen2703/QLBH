namespace BTLLTQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Create_Table_NhanVien : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.NhanViens",
                c => new
                    {
                        IDNhanVien = c.String(nullable: false, maxLength: 128),
                        TenNhanVien = c.String(),
                        SĐT = c.String(),
                    })
                .PrimaryKey(t => t.IDNhanVien);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.NhanViens");
        }
    }
}
