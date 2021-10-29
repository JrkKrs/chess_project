namespace WebApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userTokenApi : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.users", "userApiToken", c => c.String(maxLength: 110));
            DropColumn("dbo.users", "usreApiToken");
        }
        
        public override void Down()
        {
            AddColumn("dbo.users", "usreApiToken", c => c.String(maxLength: 110));
            DropColumn("dbo.users", "userApiToken");
        }
    }
}
