Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Public Class home
    Inherits System.Web.UI.Page
    Dim seccion As String
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
        'RESCATAR DATOS DE LOS TEXTBOX
        Dim fechaIngreso As String = TextFechaIng.Text
        Dim horaIngreso As String = TextHoraIng.Text
        Dim titulo As String = TextTitulo.Text.ToString
        Dim descripcion As String = TextDescripcion.Text
        Dim plateaBaja As String = TextPlateaBaja.Text
        Dim plateaAlta As String = TextPlateaAlta.Text
        Dim galeria As String = TextGaleria.Text
        Dim imagen As String

        'VERIFICAR SI HA SUBIDO UNA IMAGEN
        If FileUpload1.HasFile Then
            imagen = Path.Combine(Path.Combine(Server.MapPath("~/images/")), FileUpload1.FileName)
            FileUpload1.SaveAs(imagen)
            imagen = "/images/" + FileUpload1.FileName
            'CONEXIÓN A LA BASE DE DATO
            Using con As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("DesarrolloConnectionString").ToString)
                con.Open()
                Dim query As String = "insert into programacion values (@fecha, @hora, @titulo, @foto, @descripcion, @platea_baja, @platea_alta, @galeria, @seccion )"
                Dim cmd As SqlCommand = New SqlCommand(query, con)
                cmd.Parameters.AddWithValue("@fecha", fechaIngreso)
                cmd.Parameters.AddWithValue("@hora", horaIngreso)
                cmd.Parameters.AddWithValue("@titulo", titulo)
                cmd.Parameters.AddWithValue("@descripcion", descripcion)
                cmd.Parameters.AddWithValue("@platea_baja", plateaBaja)
                cmd.Parameters.AddWithValue("@platea_alta", plateaAlta)
                cmd.Parameters.AddWithValue("@galeria", galeria)
                cmd.Parameters.AddWithValue("@foto", imagen)
                cmd.Parameters.AddWithValue("@seccion", seccion)

                'Ejecutar query
                Try
                    cmd.ExecuteNonQuery()
                    ScriptManager.RegisterStartupScript(ButtonSubir, [GetType], "ingresoexito", "ingresoexito();", True)
                    TextFechaIng.Text = ""
                    TextHoraIng.Text = ""
                    TextTitulo.Text = ""
                    TextDescripcion.Text = ""
                    TextPlateaBaja.Text = ""
                    TextPlateaAlta.Text = ""
                    TextGaleria.Text = ""
                    checkbox.ClearSelection()
                Catch ex As System.Data.SqlClient.SqlException
                    ScriptManager.RegisterStartupScript(ButtonSubir, [GetType], "ingresofallo", "ingresofallo();", True)
                End Try
                con.Close()

            End Using

        Else
            ScriptManager.RegisterStartupScript(ButtonSubir, [GetType], "subioimagen", "subioimagen();", True)



        End If

    End Sub


    Protected Sub checkbox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles checkbox.SelectedIndexChanged
        If checkbox.Items(0).Selected Then
            seccion = "Home Pequeño"
        ElseIf checkbox.Items(1).Selected Then
            seccion = "Home Grande"
        ElseIf checkbox.Items(2).Selected Then
            seccion = "Listado"
        ElseIf checkbox.Items(3).Selected Then
            seccion = "Eventos"
        End If
    End Sub
End Class