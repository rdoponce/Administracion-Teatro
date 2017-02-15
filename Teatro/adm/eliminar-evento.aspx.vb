Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Public Class eliminar_evento
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Using con As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("DesarrolloConnectionString").ToString)
            Dim ideve As String = Request.QueryString("IdEvento").ToString
            Dim idevento As Int32 = Integer.Parse(ideve)
            con.Open()
            Dim Query As String = "DELETE FROM evento WHERE id_evento = @id_evento"
            Dim cmd As SqlCommand = New SqlCommand(Query, con)
            cmd.Parameters.AddWithValue("@id_evento", idevento)
            'Ejecutar query
            Try
                cmd.ExecuteNonQuery()
            Catch ex As System.Data.SqlClient.SqlException
            End Try
            con.Close()
        End Using
        Response.Redirect("editar-evento.aspx")
    End Sub

End Class