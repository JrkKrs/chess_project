namespace WebApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEmail : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.users", "email", c => c.String(maxLength: 128));
        }
        
        public override void Down()
        {
            DropColumn("dbo.users", "email");
        }
    }
}
