namespace mukatalev1._0.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveEmailFromRegister : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "FullName", c => c.String());
            AddColumn("dbo.AspNetUsers", "Status", c => c.Boolean(nullable: false));
            AddColumn("dbo.AspNetUsers", "Password", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Password");
            DropColumn("dbo.AspNetUsers", "Status");
            DropColumn("dbo.AspNetUsers", "FullName");
        }
    }
}
