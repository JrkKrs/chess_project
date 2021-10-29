namespace WebApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class lastActive_inGame : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.users", "lastActive", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AddColumn("dbo.users", "inGame", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.users", "inGame");
            DropColumn("dbo.users", "lastActive");
        }
    }
}
