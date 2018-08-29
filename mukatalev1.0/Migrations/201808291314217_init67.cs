namespace mukatalev1._0.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init67 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posts", "Contact", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Posts", "Contact");
        }
    }
}
