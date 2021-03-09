namespace BTLLTQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Create_Table_CuaHang : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CuaHangs",
                c => new
                    {
                        IDCuaHang = c.String(nullable: false, maxLength: 128),
                        TenCuaHang = c.String(),
                        ChiNhanh = c.String(),
                    })
                .PrimaryKey(t => t.IDCuaHang);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CuaHangs");
        }
    }
}
