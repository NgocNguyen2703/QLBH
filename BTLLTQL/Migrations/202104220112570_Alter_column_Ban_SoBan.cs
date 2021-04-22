namespace BTLLTQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Alter_column_Ban_SoBan : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Bans", "SoBan", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Bans", "SoBan");
        }
    }
}
