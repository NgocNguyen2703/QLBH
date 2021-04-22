namespace BTLLTQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Alter_column_Ca_Gio : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cas", "Gio", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Cas", "Gio");
        }
    }
}
