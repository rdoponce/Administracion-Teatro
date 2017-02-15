Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Public Class ingresar_lateral
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

    Protected Sub ButtonSubir_Click(sender As Object, e As EventArgs) Handles ButtonSubir.Click
        'RESCATAR DATOS DE TEXTBOX
        Dim fechaIngreso As String = TextFechaIng.Text
        Dim descripcion As String = TextDescripcion.Text
        Dim imagen As String

        'VALIDAR SI HA SUBIDO UNA IMAGEN
        If FileUpload1.HasFile Then
            imagen = Path.Combine(Path.Combine(Server.MapPath("~/images/")), FileUpload1.FileName)
            FileUpload1.SaveAs(imagen)
            imagen = "/images/" + FileUpload1.FileName
            'CONEXIÓN A LA BASE DE DATOS
            Using con As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("DesarrolloConnectionString").ToString)
                con.Open()
                Dim query As String = "insert into evento_lateral values (@fecha, @foto, @descripcion )"

                Dim cmd As SqlCommand = New SqlCommand(query, con)

                cmd.Parameters.AddWithValue("@fecha", fechaIngreso)
                cmd.Parameters.AddWithValue("@descripcion", descripcion)
                cmd.Parameters.AddWithValue("@foto", imagen)

                'Ejecutar query
                Try
                    cmd.ExecuteNonQuery()
                    ScriptManager.RegisterStartupScript(ButtonSubir, [GetType], "ingresoexito", "ingresoexito();", True)
                    TextFechaIng.Text = ""
                    TextDescripcion.Text = ""
                Catch ex As System.Data.SqlClient.SqlException
                    ScriptManager.RegisterStartupScript(ButtonSubir, [GetType], "ingresofallo", "ingresofallo();", True)
                End Try
                con.Close()

            End Using

        Else
            ScriptManager.RegisterStartupScript(ButtonSubir, [GetType], "subioimagen", "subioimagen();", True)



        End If

    End Sub
End Class