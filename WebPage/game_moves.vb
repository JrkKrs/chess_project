Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

Partial Public Class game_moves
    Public Property id As Integer

    Public Property gameId As Integer

    <Required>
    <StringLength(10)>
    Public Property whiteMove As String

    <StringLength(10)>
    Public Property blackMove As String

    Public Property moveOrder As Integer

    <StringLength(5)>
    Public Property annotation As String

    Public Overridable Property game As game
End Class
