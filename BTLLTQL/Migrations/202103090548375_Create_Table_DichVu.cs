namespace BTLLTQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Create_Table_DichVu : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DichVus",
                c => new
                    {
                        IDDichVu = c.String(nullable: false, maxLength: 128),
                        TenDV = c.String(),
                        IDLoaiDV = c.String(),
                    })
                .PrimaryKey(t => t.IDDichVu);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.DichVus");
        }
    }
}
