namespace mukatalev1._0.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init18 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Replies", "Username", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Replies", "Username");
        }
    }
}
