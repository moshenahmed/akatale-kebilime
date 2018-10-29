namespace mukatalev1._0.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.JobTasks", "Date", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.JobTasks", "Date");
        }
    }
}
