Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Public Class editando_evento
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            'VALIDAR DATOS DE USUARIO
            If Session("nombre_usuario") IsNot Nothing And Session("contraseña_usuario") IsNot Nothing Then
                Dim usuario As String = Session("nombre_usuario").ToString
                Dim contraseña As String = Session("contraseña_usuario").ToString
                lblusuario.Text = usuario
                'RESCATA VALOR DE ID ENVIADO POR URL
                Dim ideve As String = Request.QueryString("IdEvento").ToString
                'CONEXIÓN A LA BASE DE DATOS
                Using con As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("DesarrolloConnectionString").ToString)
                    con.Open()
                    Dim query As String = "SELECT fecha, hora, titulo, foto, descripcion, platea_baja, platea_alta FROM evento  WHERE id_evento=@id_evento"
                    Dim cmd As SqlCommand = New SqlCommand(query, con)
                    cmd.Parameters.AddWithValue("@id_evento", ideve)
                    Dim Reader As SqlDataReader = cmd.ExecuteReader()
                    'LLENAR FORMULARIO CON LOS DATOS DEL REGISTRO
                    If Reader.Read() Then
                        TextFechaMod.Text = Reader.GetValue(0).ToString
                        TextHoraMod.Text = Reader.GetValue(1).ToString
                        TextTitulo.Text = Reader.GetValue(2).ToString
                        TextDescripcion.Text = Reader.GetValue(4).ToString
                        TextPlateaBaja.Text = Reader.GetValue(5).ToString
                        TextPlateaAlta.Text = Reader.GetValue(6).ToString
                    End If
                End Using
            Else
                Response.Redirect("Login.aspx")
            End If
        End If
    End Sub

    Protected Sub ButtonModificar_Click(sender As Object, e As EventArgs) Handles ButtonModificar.Click
        'RESCATAR VALOR ID POR URL
        Dim reqeve As String = Request.QueryString("IdEvento").ToString
        'RESCATAR VALORES DE LOS TEXTBOX
        Dim fecha As String = TextFechaMod.Text
        Dim hora As String = TextHoraMod.Text
        Dim titulo As String = TextTitulo.Text
        Dim descripcion As String = TextDescripcion.Text
        Dim plateaBaja As String = TextPlateaBaja.Text
        Dim plateaAlta As String = TextPlateaAlta.Text
        Dim plateaBajaDesc As String = TextPlateaBajaDesc.Text
        Dim plateaAltaDesc As String = TextPlateaAltaDesc.Text
        Dim imagen As String

        'VERIFICAR SI HA SUBIDO UNA IMAGEN
        If FileUpload1.HasFile Then
            imagen = Path.Combine(Path.Combine(Server.MapPath("~/images/")), FileUpload1.FileName)
            FileUpload1.SaveAs(imagen)
            imagen = "/images/" + FileUpload1.FileName
            plateaAlta -= plateaAltaDesc
            plateaBaja -= plateaBajaDesc
            'CONEXIÓN A LA BASE DE DATOS
            Using con As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("DesarrolloConnectionString").ToString)
                con.Open()
                'ACTUALIZAR DATOS DEL REGISTRO
                Dim query As String = "UPDATE evento SET fecha=@fecha, hora=@hora, titulo=@titulo, foto=@foto, descripcion=@descripcion, platea_baja=@platea_baja, platea_alta=@platea_alta WHERE id_evento=@id_evento"
                Dim cmd As SqlCommand = New SqlCommand(query, con)
                cmd.Parameters.AddWithValue("@fecha", fecha)
                cmd.Parameters.AddWithValue("@hora", hora)
                cmd.Parameters.AddWithValue("@titulo", titulo)
                cmd.Parameters.AddWithValue("@descripcion", descripcion)
                cmd.Parameters.AddWithValue("@platea_baja", plateaBaja)
                cmd.Parameters.AddWithValue("@platea_alta", plateaAlta)
                cmd.Parameters.AddWithValue("@foto", imagen)
                cmd.Parameters.AddWithValue("@id_evento", reqeve)
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
                    TextPlateaBajaDesc.Text = ""
                    TextPlateaAltaDesc.Text = ""
                Catch ex As System.Data.SqlClient.SqlException
                    ScriptManager.RegisterStartupScript(ButtonModificar, [GetType], "modificarfallo", "modificarfallo();", True)
                End Try
                con.Close()

            End Using
        Else
            ScriptManager.RegisterStartupScript(ButtonModificar, [GetType], "subioimagen", "subioimagen();", True)
        End If
    End Sub
End Class