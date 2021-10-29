namespace WebApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userToken : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.users", "usreApiToken", c => c.String(maxLength: 110));
        }
        
        public override void Down()
        {
            DropColumn("dbo.users", "usreApiToken");
        }
    }
}
