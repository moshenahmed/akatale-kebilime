namespace mukatalev1._0.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addNewParamsForRegisterAndLogin : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comments", "UserId", c => c.String(maxLength: 128));
            AddColumn("dbo.Posts", "UserId", c => c.String(maxLength: 128));
            AddColumn("dbo.Replies", "UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Comments", "UserId");
            CreateIndex("dbo.Posts", "UserId");
            CreateIndex("dbo.Replies", "UserId");
            AddForeignKey("dbo.Comments", "UserId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Posts", "UserId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Replies", "UserId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Replies", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Posts", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Comments", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Replies", new[] { "UserId" });
            DropIndex("dbo.Posts", new[] { "UserId" });
            DropIndex("dbo.Comments", new[] { "UserId" });
            DropColumn("dbo.Replies", "UserId");
            DropColumn("dbo.Posts", "UserId");
            DropColumn("dbo.Comments", "UserId");
        }
    }
}
