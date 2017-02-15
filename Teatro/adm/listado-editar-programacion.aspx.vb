Imports System
Imports System.IO
Imports System.Data.SqlClient
Imports System.Data
Public Class listado_editar_programacion
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

    Protected Sub lvprog_ItemDataBound(ByVal sender As Object, ByVal e As ListViewItemEventArgs) Handles lvprog.ItemDataBound
        'ENVIAR ID POR URL PARA MODIFICAR EL REGISTRO
        Dim ItemAux As DataRowView = DirectCast(DirectCast(e.Item, ListViewDataItem).DataItem, DataRowView)
        Dim lbprogramacion As LinkButton = e.Item.FindControl("lb")
        Dim lbid As Label = e.Item.FindControl("id_programacionLabel")
        lbprogramacion.PostBackUrl = "editar-programacion.aspx?IdProgramacion=" & ItemAux.Row.Item("id_programacion")

        'ENVIAR ID POR URL PARA ELIMINAR EL RETGISTRO
        Dim lbeliminar As LinkButton = e.Item.FindControl("lbeliminar")
        lbeliminar.PostBackUrl = "eliminar-programacion.aspx?IdProgramacion=" & ItemAux.Row.Item("id_programacion")


    End Sub
End Class