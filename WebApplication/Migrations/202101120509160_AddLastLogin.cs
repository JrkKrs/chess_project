namespace WebApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddLastLogin : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.users", "lastLogin", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            DropColumn("dbo.users", "lastLogin");
        }
    }
}
