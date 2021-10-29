Imports System
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity
Imports System.Linq

Partial Public Class Model1
    Inherits DbContext

    Public Sub New()
        MyBase.New("name=chess")
    End Sub

    Public Overridable Property game As DbSet(Of game)
    Public Overridable Property game_moves As DbSet(Of game_moves)
    Public Overridable Property users As DbSet(Of users)

    Protected Overrides Sub OnModelCreating(ByVal modelBuilder As DbModelBuilder)
        modelBuilder.Entity(Of game)() _
            .HasMany(Function(e) e.game_moves) _
            .WithRequired(Function(e) e.game) _
            .WillCascadeOnDelete(False)

        modelBuilder.Entity(Of users)() _
            .HasMany(Function(e) e.game) _
            .WithRequired(Function(e) e.users) _
            .HasForeignKey(Function(e) e.whiteUserId) _
            .WillCascadeOnDelete(False)

        modelBuilder.Entity(Of users)() _
            .HasMany(Function(e) e.game1) _
            .WithRequired(Function(e) e.users1) _
            .HasForeignKey(Function(e) e.blackUserId) _
            .WillCascadeOnDelete(False)
    End Sub
End Class
