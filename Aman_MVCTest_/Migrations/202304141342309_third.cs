namespace Aman_MVCTest_.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class third : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Blogs", "Disabled", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Blogs", "Disabled");
        }
    }
}
