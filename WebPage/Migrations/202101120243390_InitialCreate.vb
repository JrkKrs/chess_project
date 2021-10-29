Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class InitialCreate
        Inherits DbMigration
    
        Public Overrides Sub Up()
            CreateTable(
                "dbo.game",
                Function(c) New With
                    {
                        .id = c.Int(nullable := False, identity := True),
                        .whiteUserId = c.Int(nullable := False),
                        .blackUserId = c.Int(nullable := False),
                        .startDate = c.DateTime(nullable := False, precision := 7, storeType := "datetime2"),
                        .endDate = c.DateTime(precision := 7, storeType := "datetime2"),
                        .winner = c.Short()
                    }) _
                .PrimaryKey(Function(t) t.id) _
                .ForeignKey("dbo.users", Function(t) t.whiteUserId) _
                .ForeignKey("dbo.users", Function(t) t.blackUserId) _
                .Index(Function(t) t.whiteUserId) _
                .Index(Function(t) t.blackUserId)
            
            CreateTable(
                "dbo.game_moves",
                Function(c) New With
                    {
                        .id = c.Int(nullable := False, identity := True),
                        .gameId = c.Int(nullable := False),
                        .whiteMove = c.String(nullable := False, maxLength := 10),
                        .blackMove = c.String(maxLength := 10),
                        .moveOrder = c.Int(nullable := False),
                        .annotation = c.String(maxLength := 5)
                    }) _
                .PrimaryKey(Function(t) t.id) _
                .ForeignKey("dbo.game", Function(t) t.gameId) _
                .Index(Function(t) t.gameId)
            
            CreateTable(
                "dbo.users",
                Function(c) New With
                    {
                        .id = c.Int(nullable := False, identity := True),
                        .username = c.String(maxLength := 20),
                        .displayName = c.String(maxLength := 50),
                        .passwd = c.String(maxLength := 128),
                        .lastLogin = c.Int()
                    }) _
                .PrimaryKey(Function(t) t.id)
            
        End Sub
        
        Public Overrides Sub Down()
            DropForeignKey("dbo.game", "blackUserId", "dbo.users")
            DropForeignKey("dbo.game", "whiteUserId", "dbo.users")
            DropForeignKey("dbo.game_moves", "gameId", "dbo.game")
            DropIndex("dbo.game_moves", New String() { "gameId" })
            DropIndex("dbo.game", New String() { "blackUserId" })
            DropIndex("dbo.game", New String() { "whiteUserId" })
            DropTable("dbo.users")
            DropTable("dbo.game_moves")
            DropTable("dbo.game")
        End Sub
    End Class
End Namespace
