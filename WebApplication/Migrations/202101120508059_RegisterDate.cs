namespace WebApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RegisterDate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.users", "registerDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            DropColumn("dbo.users", "lastLogin");
        }
        
        public override void Down()
        {
            AddColumn("dbo.users", "lastLogin", c => c.Int());
            DropColumn("dbo.users", "registerDate");
        }
    }
}
