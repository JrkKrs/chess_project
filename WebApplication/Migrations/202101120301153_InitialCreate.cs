namespace WebApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.game",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        whiteUserId = c.Int(nullable: false),
                        blackUserId = c.Int(nullable: false),
                        startDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        endDate = c.DateTime(precision: 7, storeType: "datetime2"),
                        winner = c.Short(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.users", t => t.whiteUserId)
                .ForeignKey("dbo.users", t => t.blackUserId)
                .Index(t => t.whiteUserId)
                .Index(t => t.blackUserId);
            
            CreateTable(
                "dbo.game_moves",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        gameId = c.Int(nullable: false),
                        whiteMove = c.String(nullable: false, maxLength: 10),
                        blackMove = c.String(maxLength: 10),
                        moveOrder = c.Int(nullable: false),
                        annotation = c.String(maxLength: 5),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.game", t => t.gameId)
                .Index(t => t.gameId);
            
            CreateTable(
                "dbo.users",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        username = c.String(maxLength: 20),
                        displayName = c.String(maxLength: 50),
                        passwd = c.String(maxLength: 128),
                        lastLogin = c.Int(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.game", "blackUserId", "dbo.users");
            DropForeignKey("dbo.game", "whiteUserId", "dbo.users");
            DropForeignKey("dbo.game_moves", "gameId", "dbo.game");
            DropIndex("dbo.game_moves", new[] { "gameId" });
            DropIndex("dbo.game", new[] { "blackUserId" });
            DropIndex("dbo.game", new[] { "whiteUserId" });
            DropTable("dbo.users");
            DropTable("dbo.game_moves");
            DropTable("dbo.game");
        }
    }
}
