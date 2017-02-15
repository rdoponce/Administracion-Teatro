Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Public Class editar_programacion
    Inherits System.Web.UI.Page
    Dim seccion As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'VALIDAR DATOS DE USUARIO
        If Session("nombre_usuario") IsNot Nothing And Session("contraseña_usuario") IsNot Nothing Then
            Dim usuario As String = Session("nombre_usuario").ToString
            Dim contraseña As String = Session("contraseña_usuario").ToString
            lblusuario.Text = usuario
            'RESCATA VALOR DE ID ENVIADO POR URL
            Dim idprog As String = Request.QueryString("IdProgramacion").ToString
            'CONEXIÓN A LA BASE DE DATOS
            Using con As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("DesarrolloConnectionString").ToString)
                con.Open()
                Dim query As String = "SELECT fecha, hora, titulo, foto, descripcion, platea_baja, platea_alta, galeria, seccion FROM programacion  WHERE id_programacion=@id_programacion"
                Dim cmd As SqlCommand = New SqlCommand(query, con)
                cmd.Parameters.AddWithValue("@id_programacion", idprog)
                Dim Reader As SqlDataReader = cmd.ExecuteReader()
                'LLENAR FORMULARIO CON LOS DATOS DEL REGISTRO
                If Reader.Read() Then
                    TextFechaMod.Text = Reader.GetValue(0).ToString
                    TextHoraMod.Text = Reader.GetValue(1).ToString
                    TextTitulo.Text = Reader.GetValue(2).ToString
                    TextDescripcion.Text = Reader.GetValue(4).ToString
                    TextPlateaBaja.Text = Reader.GetValue(5).ToString
                    TextPlateaAlta.Text = Reader.GetValue(6).ToString
                    TextGaleria.Text = Reader.GetValue(7).ToString
                    seccion = Reader.GetValue(8).ToString
                End If

                'MARCAR CHECKBOX 
                Select Case seccion
                    Case "Home Pequeño"
                        checkbox.Items(0).Selected = True
                    Case "Home Grande"
                        checkbox.Items(1).Selected = True
                    Case "Listado"
                        checkbox.Items(2).Selected = True
                    Case "Eventos"
                        checkbox.Items(3).Selected = True
                End Select
            End Using
        Else
            Response.Redirect("Login.aspx")
        End If
    End Sub

    Protected Sub ButtonModificar_Click(sender As Object, e As EventArgs) Handles ButtonModificar.Click
        'RESCATAR VALOR ID POR URL
        Dim reqprog As String = Request.QueryString("IdProgramacion").ToString
        'RESCATAR VALORES DE LOS TEXTBOX
        Dim fecha As String = TextFechaMod.Text
        Dim hora As String = TextHoraMod.Text
        Dim titulo As String = TextTitulo.Text
        Dim descripcion As String = TextDescripcion.Text
        Dim plateaBaja As String = TextPlateaBaja.Text
        Dim plateaAlta As String = TextPlateaBaja.Text
        Dim galeria As String = TextGaleria.Text
        Dim imagen As String

        'VERIFICAR SI HA SUBIDO UNA IMAGEN
        If FileUpload1.HasFile Then
            imagen = Path.Combine(Path.Combine(Server.MapPath("~/images/")), FileUpload1.FileName)
            FileUpload1.SaveAs(imagen)
            imagen = "/images/" + FileUpload1.FileName
            'CONEXIÓN A LA BASE DE DATOS
            Using con As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("DesarrolloConnectionString").ToString)
                con.Open()
                'ACTUALIZAR DATOS DEL REGISTRO
                Dim query As String = "UPDATE programacion SET fecha=@fecha, hora=@hora, titulo=@titulo, foto=@foto, descripcion=@descripcion, platea_baja=@platea_baja, platea_alta=@platea_alta, galeria=@galeria, seccion=@seccion WHERE id_programacion=@id_programacion"
                Dim cmd As SqlCommand = New SqlCommand(query, con)
                cmd.Parameters.AddWithValue("@fecha", fecha)
                cmd.Parameters.AddWithValue("@hora", hora)
                cmd.Parameters.AddWithValue("@titulo", titulo)
                cmd.Parameters.AddWithValue("@descripcion", descripcion)
                cmd.Parameters.AddWithValue("@platea_baja", plateaBaja)
                cmd.Parameters.AddWithValue("@platea_alta", plateaAlta)
                cmd.Parameters.AddWithValue("@galeria", galeria)
                cmd.Parameters.AddWithValue("@foto", imagen)
                cmd.Parameters.AddWithValue("@id_programacion", reqprog)
                cmd.Parameters.AddWithValue("@seccion", seccion)
                'Ejecutar query
                Try
                    cmd.ExecuteNonQuery()
                    ScriptManager.RegisterStartupScript(ButtonModificar, [GetType], "modificarexito", "modificarexito();", True)
                    TextFechaMod.Text = ""
                    TextHoraMod.Text = ""
                    TextTitulo.Text = ""
                    TextDescripcion.Text = ""
                    TextPlateaBaja.Text = ""
                    TextPlateaAlta.Text = ""
                    TextGaleria.Text = ""
                    checkbox.ClearSelection()
                Catch ex As System.Data.SqlClient.SqlException
                    ScriptManager.RegisterStartupScript(ButtonModificar, [GetType], "modificarfallo", "modificarfallo();", True)
                End Try
                con.Close()

            End Using
        Else
            ScriptManager.RegisterStartupScript(ButtonModificar, [GetType], "subioimagen", "subioimagen();", True)
        End If
    End Sub

    Protected Sub checkbox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles checkbox.SelectedIndexChanged
        'VERIFICAR QUE SELECCIONE SOLO UN CHECKBOX
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