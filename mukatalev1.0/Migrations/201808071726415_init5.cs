namespace mukatalev1._0.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init5 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Replies", name: "Post_Id", newName: "Comment_Id");
            RenameIndex(table: "dbo.Replies", name: "IX_Post_Id", newName: "IX_Comment_Id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Replies", name: "IX_Comment_Id", newName: "IX_Post_Id");
            RenameColumn(table: "dbo.Replies", name: "Comment_Id", newName: "Post_Id");
        }
    }
}
