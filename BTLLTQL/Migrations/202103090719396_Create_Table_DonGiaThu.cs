namespace BTLLTQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Create_Table_DonGiaThu : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DonGiaThus",
                c => new
                    {
                        IDPhieuThu = c.String(nullable: false, maxLength: 128),
                        IDDichVu = c.String(),
                        TenDV = c.String(),
                        DonGia = c.String(),
                    })
                .PrimaryKey(t => t.IDPhieuThu);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.DonGiaThus");
        }
    }
}
