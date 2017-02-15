﻿Imports System
Imports System.IO
Imports System.Data.SqlClient
Imports System.Data
Public Class editar_lateral
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'VALIDAR DATOS DE USUARIO
        If Session("nombre_usuario") IsNot Nothing And Session("contraseña_usuario") IsNot Nothing Then
            Dim usuario As String = Session("nombre_usuario").ToString
            Dim contraseña As String = Session("contraseña_usuario").ToString
            lblusuario.Text = usuario
        Else
            Response.Redirect("Login.aspx")
        End If
    End Sub

    Protected Sub lvlat_ItemDataBound(ByVal sender As Object, ByVal e As ListViewItemEventArgs) Handles lvlat.ItemDataBound
        'ENVIAR ID POR URL PARA MODIFICAR EL REGISTRO
        Dim ItemAux As DataRowView = DirectCast(DirectCast(e.Item, ListViewDataItem).DataItem, DataRowView)
        Dim lbevento As LinkButton = e.Item.FindControl("lb")
        Dim lbid As Label = e.Item.FindControl("id_evento_lateralLabel")
        lbevento.PostBackUrl = "editando-lateral.aspx?IdLateral=" & ItemAux.Row.Item("id_evento_lateral")

        'ENVIAR ID POR URL PARA ELIMINAR EL RETGISTRO
        Dim lbeliminar As LinkButton = e.Item.FindControl("lbeliminar")
        lbeliminar.PostBackUrl = "eliminar-lateral.aspx?IdLateral=" & ItemAux.Row.Item("id_evento_lateral")

    End Sub
End Class