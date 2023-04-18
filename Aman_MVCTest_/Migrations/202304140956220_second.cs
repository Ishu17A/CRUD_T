namespace Aman_MVCTest_.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class second : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Blogs", "Users_UserId", "dbo.Users");
            DropIndex("dbo.Blogs", new[] { "Users_UserId" });
            DropColumn("dbo.Blogs", "Users_UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Blogs", "Users_UserId", c => c.Guid());
            CreateIndex("dbo.Blogs", "Users_UserId");
            AddForeignKey("dbo.Blogs", "Users_UserId", "dbo.Users", "UserId");
        }
    }
}
