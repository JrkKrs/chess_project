namespace WebApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_LoginMsgError : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.users", "LoginMsgError", c => c.String());
            AlterColumn("dbo.users", "username", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.users", "passwd", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.users", "username", unique: true);
            CreateIndex("dbo.users", "displayName", unique: true);
            CreateIndex("dbo.users", "email", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.users", new[] { "email" });
            DropIndex("dbo.users", new[] { "displayName" });
            DropIndex("dbo.users", new[] { "username" });
            AlterColumn("dbo.users", "passwd", c => c.String(maxLength: 128));
            AlterColumn("dbo.users", "username", c => c.String(maxLength: 20));
            DropColumn("dbo.users", "LoginMsgError");
        }
    }
}
