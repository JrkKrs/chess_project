Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

Partial Public Class users
    Public Sub New()
        game = New HashSet(Of game)()
        game1 = New HashSet(Of game)()
    End Sub

    Public Property id As Integer

    <StringLength(20)>
    Public Property username As String

    <StringLength(50)>
    Public Property displayName As String

    <StringLength(128)>
    Public Property passwd As String

    Public Property lastLogin As Integer?

    Public Overridable Property game As ICollection(Of game)

    Public Overridable Property game1 As ICollection(Of game)
End Class
