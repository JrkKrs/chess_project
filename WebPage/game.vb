Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

<Table("game")>
Partial Public Class game
    Public Sub New()
        game_moves = New HashSet(Of game_moves)()
    End Sub

    Public Property id As Integer

    Public Property whiteUserId As Integer

    Public Property blackUserId As Integer

    <Column(TypeName:="datetime2")>
    Public Property startDate As Date

    <Column(TypeName:="datetime2")>
    Public Property endDate As Date?

    Public Property winner As Short?

    Public Overridable Property game_moves As ICollection(Of game_moves)

    Public Overridable Property users As users

    Public Overridable Property users1 As users
End Class
