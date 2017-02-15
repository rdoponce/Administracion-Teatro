Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Public Class eliminar_lateral
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Using con As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("DesarrolloConnectionString").ToString)
            Dim idlat As String = Request.QueryString("IdLateral").ToString
            Dim idlateral As Int32 = Integer.Parse(idlat)
            con.Open()
            Dim Query As String = "DELETE FROM evento_lateral WHERE id_evento_lateral = @id_evento_lateral"
            Dim cmd As SqlCommand = New SqlCommand(Query, con)
            cmd.Parameters.AddWithValue("@id_evento_lateral", idlateral)
            'Ejecutar query
            Try
                cmd.ExecuteNonQuery()
            Catch ex As System.Data.SqlClient.SqlException
            End Try
            con.Close()
        End Using
        Response.Redirect("editar-lateral.aspx")
    End Sub

End Class