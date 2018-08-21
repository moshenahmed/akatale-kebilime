namespace mukatalev1._0.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init9 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Replies", "Comment_Id", "dbo.Comments");
            DropIndex("dbo.Replies", new[] { "Comment_Id" });
            RenameColumn(table: "dbo.Replies", name: "Comment_Id", newName: "CommentId");
            AlterColumn("dbo.Replies", "CommentId", c => c.Int(nullable: false));
            CreateIndex("dbo.Replies", "CommentId");
            AddForeignKey("dbo.Replies", "CommentId", "dbo.Comments", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Replies", "CommentId", "dbo.Comments");
            DropIndex("dbo.Replies", new[] { "CommentId" });
            AlterColumn("dbo.Replies", "CommentId", c => c.Int());
            RenameColumn(table: "dbo.Replies", name: "CommentId", newName: "Comment_Id");
            CreateIndex("dbo.Replies", "Comment_Id");
            AddForeignKey("dbo.Replies", "Comment_Id", "dbo.Comments", "Id");
        }
    }
}
