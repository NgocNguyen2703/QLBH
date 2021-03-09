namespace BTLLTQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Create_Table_DonGiaChi : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DonGiaChis",
                c => new
                    {
                        IDPhieuChi = c.String(nullable: false, maxLength: 128),
                        IDDonHang = c.String(),
                        TongTienHang = c.String(),
                    })
                .PrimaryKey(t => t.IDPhieuChi);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.DonGiaChis");
        }
    }
}
