Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Public Class eliminar_programacion
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Using con As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("DesarrolloConnectionString").ToString)
            Dim idprog As String = Request.QueryString("IdProgramacion").ToString
            Dim idprogramacion As Int32 = Integer.Parse(idprog)
            con.Open()
            Dim Query As String = "DELETE FROM programacion WHERE id_programacion = @id_programacion"
            Dim cmd As SqlCommand = New SqlCommand(Query, con)
            cmd.Parameters.AddWithValue("@id_programacion", idprogramacion)
            'Ejecutar query
            Try
                cmd.ExecuteNonQuery()
            Catch ex As System.Data.SqlClient.SqlException
            End Try
            con.Close()
        End Using
        Response.Redirect("listado-editar-programacion.aspx")
    End Sub

End Class