namespace mukatalev1._0.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class jobtasksanduserbidstable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.JobTasks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        JobDescription = c.String(),
                        Image = c.String(),
                        MainBid = c.Int(nullable: false),
                        UserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.UserBids",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MyBid = c.Int(nullable: false),
                        JobTaskId = c.Int(nullable: false),
                        UserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.JobTasks", t => t.JobTaskId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.JobTaskId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserBids", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.UserBids", "JobTaskId", "dbo.JobTasks");
            DropForeignKey("dbo.JobTasks", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.UserBids", new[] { "UserId" });
            DropIndex("dbo.UserBids", new[] { "JobTaskId" });
            DropIndex("dbo.JobTasks", new[] { "UserId" });
            DropTable("dbo.UserBids");
            DropTable("dbo.JobTasks");
        }
    }
}
