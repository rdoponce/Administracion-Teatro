Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Public Class Login
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'RECORDAR USUARIO CUANDO MARCA EL CHECKBOX RECORDAR
        If Not IsPostBack Then
            If Request.Cookies("usuario") IsNot Nothing Then
                TextUsuario.Text = Request.Cookies("usuario").Value
                CheckRecordar.Checked = True
            End If
        End If
    End Sub

    Protected Sub ButtonIngresar_Click(sender As Object, e As EventArgs) Handles ButtonIngresar.Click
        Dim usuario As String = TextUsuario.Text
        Dim contraseña As String = TextContraseña.Text
        'DARLE VALOR A LAS COOKIES 
        If CheckRecordar.Checked = True Then
            Response.Cookies("usuario").Expires = DateTime.Now.AddDays(1)
            Response.Cookies("usuario").Value = TextUsuario.Text
        Else
            Response.Cookies("usuario").Expires = DateTime.Now.AddDays(-1)
        End If


        'CONEXION A LA BASE DE DATOS
        Using con As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("DesarrolloConnectionString").ToString)
            con.Open()
            Dim query As String = "SELECT nombre_usuario, contraseña_usuario FROM usuario WHERE nombre_usuario=@nombre_usuario AND contraseña_usuario=@contraseña_usuario "

            Dim cmd As SqlCommand = New SqlCommand(query, con)

            cmd.Parameters.AddWithValue("@nombre_usuario", usuario)
            cmd.Parameters.AddWithValue("@contraseña_usuario", contraseña)

            'Ejecutar query
            Try
                Dim dr As SqlDataReader = cmd.ExecuteReader
                If dr.Read Then
                    Session("nombre_usuario") = usuario
                    Session("contraseña_usuario") = contraseña
                    Response.Redirect("home.aspx")

                Else
                    ScriptManager.RegisterStartupScript(ButtonIngresar, [GetType], "ingresofallo", "ingresofallo();", True)
                End If
            Catch ex As System.Data.SqlClient.SqlException
            End Try
            con.Close()
        End Using
    End Sub
End Class