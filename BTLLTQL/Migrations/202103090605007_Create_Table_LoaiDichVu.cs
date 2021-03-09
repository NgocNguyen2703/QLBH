namespace BTLLTQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Create_Table_LoaiDichVu : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LoaiDichVus",
                c => new
                    {
                        IDLoaiDichVu = c.String(nullable: false, maxLength: 128),
                        TenLoaiDichVu = c.String(),
                    })
                .PrimaryKey(t => t.IDLoaiDichVu);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.LoaiDichVus");
        }
    }
}
